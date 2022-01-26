using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SPJMD.Models.Enums;

namespace SPJMD.Models
{
    public class Procedimento
    {
        public int Id { get; set; }
        public TiposProcedimentos TipoProcedimento { get; set; }
        public string Opm { get; set; }
        public int Numero { get; set; }
        public string Prefixo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public Origem Origem { get; set; }
        public Oficial Oficial { get; set; }

        public ICollection<Policial> Policiais { get; set; } = new List<Policial>();

        public Procedimento()
        {
        }

        public Procedimento(int id, TiposProcedimentos tipoProcedimento, string opm, int numero, string prefixo, DateTime data, Origem origem, Oficial oficial)
        {
            Id = id;
            TipoProcedimento = tipoProcedimento;
            Opm = opm;
            Numero = numero;
            Prefixo = prefixo;
            Data = data;
            Origem = origem;
            Oficial = oficial;
        }

        //Total de Policiais
        public int TotalPM()
        {
            return Policiais.Count();
        }
    }
}
