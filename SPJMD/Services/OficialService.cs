using SPJMD.Data;
using SPJMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPJMD.Services
{
    public class OficialService 
    {
        private readonly SPJMDContext _context;
        


        public OficialService(SPJMDContext context)
        {
            _context = context;
          
        }

        // Operação para retornar uma lista com todos Oficiais do Banco de Dados
        public List<Oficial> FindAll()
        {
            //Acessa a fonte de dados da tabela Oficiais e converte em uma lista.
            return _context.Oficial.ToList();
            
        }
    }
}
