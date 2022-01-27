using Microsoft.AspNetCore.Mvc;
using SPJMD.Models;
using SPJMD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPJMD.Controllers
{
    public class OficiaisController : Controller
    {
        //Dependência para o OficialService
        private readonly OficialService _oficialService;

        public OficiaisController(OficialService oficialService)
        {
            _oficialService = oficialService;
        }

        // Página inicial do Oficiais
        public IActionResult Index()
        {
            //Essa operação retorna uma lista de Oficiais               
            var lista = _oficialService.FindAll();
            
            return View(lista); // Passo a lista criada como argumento da View
            /* Essa lista que nós implementamos aqui é o objeto @model que vamos criar na página
             Index da nossa pasta Oficiais. */
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Oficial oficial)
        {
            _oficialService.Insert(oficial);
            return RedirectToAction(nameof(Index));
        }
    }
}
