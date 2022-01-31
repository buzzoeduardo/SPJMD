using SPJMD.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace SPJMD.Models
{
    public class Policial
    {
        
        public int Id { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Somente números são permitidos.")]
        [Required(ErrorMessage = "RE Obrigatório.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O {0} deve ter conter {1} dígitos.")]
        [Display(Name = "RE")]
        public string Re { get; set; }

        [Required(ErrorMessage = "Dígito Obrigatório.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Dígito Obrigatório")]
        [Display(Name = "DIG")]        
        public string Digito { get; set; }

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

        public ICollection<Procedimento> Procedimentos { get; set; } = new List<Procedimento>();       


        public Policial()
        {
        }

        public Policial(int id, string re, string digito, PostGrad graduacao, string nome, QualificacaoEnvolvido status)
        {
            Id = id;
            Re = re;
            Digito = digito;
            Graduacao = graduacao;
            Nome = nome;
            Status = status;
        }

        //Total de Procedimentos
        public int TotalProcPM()
        {
            return Procedimentos.Count();
        }

        //Tipos de Procedimentos

        public void TiposProcPM()
        {
            var filtro = Procedimentos.Where(x => x.TipoProcedimento != null).ToList();
            foreach (var tipo in filtro)
            {
                Console.WriteLine(tipo.TipoProcedimento 
                    + " - " + tipo.Opm + "-" + tipo.Numero 
                    + "/" + tipo.Prefixo + "/" 
                    + tipo.Data);
            }
        }


        public override string ToString()
        {
            return Graduacao + " " + Re + "-" + Digito + "  " + Nome;
        }              
    }
}
