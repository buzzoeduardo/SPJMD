using SPJMD.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPJMD.Models
{
    public class Policial
    {
        
        public int Id { get; set; }

        [Display(Name = "RE")]
        public int Re { get; set; }

        [Display(Name = "DIG")]        
        public string Digito { get; set; }

        [Display(Name = "GRADUAÇÃO")]
        public PostGrad Graduacao { get; set; }
        public string Nome { get; set; }
        public QualificacaoEnvolvido Status { get; set; }
        //public ICollection<IPM> IPMs { get; set; } = new List<IPM>();

        public Policial()
        {
        }

        public Policial(int id, int re, string digito, PostGrad graduacao, string nome, QualificacaoEnvolvido status)
        {
            Id = id;
            Re = re;
            Digito = digito;
            Graduacao = graduacao;
            Nome = nome;
            Status = status;
        }
    }
}
