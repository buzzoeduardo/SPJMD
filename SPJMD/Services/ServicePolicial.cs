using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPJMD.Data;
using SPJMD.Models;
using SPJMD.Services.Exceptions;

namespace SPJMD.Services
{
    public class ServicePolicial
    {
        private readonly SPJMDContext _context;

        public ServicePolicial(SPJMDContext context)
        {
            _context = context;
        }

        public async Task<List<Policial>> RetornarTodos()
        {
            return await _context.Policial.ToListAsync();
        }

        

        public async Task<List<Policial>> BuscaPorReAsync(string re)
        {

            var resultado = from obj in _context.Policial select obj;

            if (!String.IsNullOrEmpty(re))
            {
                resultado = resultado.Where(x => x.Re.Contains(re) || x.Nome.Contains(re));
                
            }           
            //resultado = resultado.Where(x => x.Re.Contains(re));
            return await resultado.ToListAsync(); 
        }

       

        public void Update(Policial obj)
        {
            if (!_context.Policial.Any(x => x.Id == obj.Id))
            {
                throw new ExceNaoEncontrada("Esse Id não existe no banco de dados.");
            }
            try
            {
                if (!_context.Policial.Any(x => x.Re == obj.Re))
                {
                    try
                    {
                        _context.Update(obj);
                        _context.SaveChanges();
                    }
                    catch (DbUpdateException e)
                    {
                        throw new ExcBancoDados(e.Message);
                    }                   
                }
                else
                {
                    throw new ExceNaoEncontrada("Esse RE já existe na base de dados.");
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ExcBancoDados(e.Message);
            }           
        }   

        public void Insert(Policial policial)
        { 
            if (!_context.Policial.Any(x => x.Re == policial.Re))
            {
                try
                {
                    _context.Add(policial);
                    _context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    throw new ExcBancoDados(e.Message);
                }
            }
            else
            {                
               throw new ExceNaoEncontrada("Esse RE já existe na base de dados.");
            }
        }        


        public void Remover(int id)
        {
            var obj = _context.Policial.Find(id);
            _context.Policial.Remove(obj);
            _context.SaveChanges();
        }



        public async Task<Policial> IdExistente(int id)
        {
            return await _context.Policial.FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<Policial> ReExiste(string re)
        {
            return await _context.Policial.FirstOrDefaultAsync(x => x.Re == re);
        }
    }
}
