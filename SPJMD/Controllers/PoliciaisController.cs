using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SPJMD.Data;
using SPJMD.Models;
using SPJMD.Models.ViewModels;
using SPJMD.Services;
using SPJMD.Services.Exceptions;

namespace SPJMD.Controllers
{
    public class PoliciaisController : Controller
    {
        private readonly SPJMDContext _context;
        private readonly ServicePolicial _servicePolicial;
        
        public PoliciaisController(SPJMDContext context, ServicePolicial servicePolicial)
        {
            _context = context;
            _servicePolicial = servicePolicial;
        }        

      
        public async Task<IActionResult> Index()
        {
            var lista = await _servicePolicial.RetornarTodos();
            return View(lista);           
        }       

        //----------------------------------------------------------------
        //Detalhes
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id inexistente." });
            }

            var policial = await _servicePolicial.IdExistente(id.Value);

            if (policial == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id inexistente." });
            }

            return View(policial);
        }

        //----------------------------------------------------------------
        //Criar

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Policial policial)
        {
            try
            {
                _servicePolicial.Insert(policial);
                return RedirectToAction(nameof(Index));
            }

            catch (ExceNaoEncontrada e)
            {
                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }
           
        }


        //----------------------------------------------------------------
        //Editar

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var policial = await _servicePolicial.IdExistente(id.Value);
            if (policial == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id inexistente." });
            }
             
            return View(policial);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Re,Digito,Graduacao,Nome,Status")] Policial policial)
        {
            if (id != policial.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Os Id não correspendem." });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    try
                    {
                        _servicePolicial.Update(policial);
                        await _context.SaveChangesAsync();
                    }

                    catch (ExceNaoEncontrada e)
                    {
                        return RedirectToAction(nameof(Error), new { mensagem = e.Message });
                    }
                    
                   
                }
                catch (ExceNaoEncontrada e)
                {
                    if (!PolicialExists(policial.Id))
                    {
                        return RedirectToAction(nameof(Error), new { message = e.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (ExcBancoDados e)
                {
                    return RedirectToAction(nameof(Error), new { message = e.Message });
                }
                return RedirectToAction(nameof(Index));
            }
            return View(policial);
        }


        //----------------------------------------------------------------
        //Deletar

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id inexistente." });
            }

            var policial = await _servicePolicial.IdExistente(id.Value);
            
            if (policial == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id inexistente." });
            }

            return View(policial);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _servicePolicial.Remover(id);
            return RedirectToAction(nameof(Index));  
        }

        //----------------------------------------------------------------

        private bool PolicialExists(int id)
        {
            return _context.Policial.Any(e => e.Id == id);
        }



        public async Task<IActionResult> BuscaSimples(string re)
        {           
            var resultado = await _servicePolicial.BuscaPorReAsync(re);
            return View(resultado);
        }
       
        public IActionResult Error(string mensagem)
        {
            var modeloErro = new ErrorViewModel
            {
                Message = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(modeloErro);
        }
    }
}
