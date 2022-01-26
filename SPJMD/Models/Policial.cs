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

        [Required(ErrorMessage = "RE Obrigatório.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O {0} deve ter conter {1} dígitos.")]
        [Display(Name = "RE")]
        public int Re { get; set; }

        [Required(ErrorMessage = "Dígito Obrigatório.")]
        [StringLength(1, MinimumLength = 1)]
        [Display(Name = "DIG")]        
        public char Digito { get; set; }

        [Required(ErrorMessage = "Selecione uma Graduação válida")]
        [Display(Name = "GRADUAÇÃO")]
        public PostGrad Graduacao { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "O {0} deve ter conter no mínimo {2} dígitos.")]
        [Required(ErrorMessage = "Nome Obrigatório.")] 
        [Display(Name = "NOME")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione uma Condição válida")]
        [Display(Name = "CONDIÇÃO")]
        public QualificacaoEnvolvido Status { get; set; }
        //public ICollection<IPM> IPMs { get; set; } = new List<IPM>();

        public Policial()
        {
        }

        public Policial(int id, int re, char digito, PostGrad graduacao, string nome, QualificacaoEnvolvido status)
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
