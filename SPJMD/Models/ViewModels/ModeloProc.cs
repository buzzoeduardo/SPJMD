using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPJMD.Models;
using SPJMD.Data;

namespace SPJMD.Models.ViewModels
{
    public class ModeloProc
    {
        public Oficial Oficial { get; set; }
        public Procedimento Procedimento { get; set; }

        SPJMDContext contexto = new SPJMDContext();
        public int Total()
        {
            var total = from o in contexto.Oficial
                        join p in contexto.Procedimento
                        on o.Id equals p.Oficial.Id
                        select new
                        {
                            Nome = o.Nome,
                            Tipo = p.TipoProcedimento
                        };
            return total.Count();
        }
    }
}
