using SPJMD.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPJMD.Models
{
    public class Investigado
    {
        [Display(Name = "RE")]
        public int Id { get; set; }       
        public string Digito { get; set; }
        public Grad Graduacao { get; set; }
        public string Nome { get; set; }
        public QualificacaoEnvolvido Status { get; set; }

        public Investigado()
        {
        }

        public Investigado(int id, string digito, Grad graduacao, string nome, QualificacaoEnvolvido status)
        {
            Id = id;            
            Digito = digito;
            Graduacao = graduacao;
            Nome = nome;
            Status = status;
        }
    }
}
