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
    }
}
