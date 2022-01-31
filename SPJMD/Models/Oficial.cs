using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SPJMD.Models.Enums;
using SPJMD.Data;

namespace SPJMD.Models
{
    public class Oficial
    {
        public int Id { get; set; }
        [RegularExpression(@"[0-9]*$")]
        [Required(ErrorMessage = "RE Obrigatório.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O {0} deve ter conter {1} dígitos.")]
        [Display(Name = "RE")]
        public string Re { get; set; }

        [Required(ErrorMessage = "Dígito Obrigatório.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Dígito Obrigatório")]
        [Display(Name = "DIG")]
        public string Digito { get; set; }

        [Required(ErrorMessage = "Selecione uma Graduação válida")]
        [Display(Name = "POSTO")]
        public Posto Posto { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "O {0} deve ter conter no mínimo {2} dígitos.")]
        [Required(ErrorMessage = "Nome obrigatório.")]
        [Display(Name = "NOME")]
        public string Nome { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "E-mail obrigatório.")]
        [Display(Name = "E-MAIL")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Selecione uma Condição válida")]
        [Display(Name = "CONDIÇÃO")]
        public FuncaoOficial Status { get; set; }

        public ICollection<Procedimento> Procedimentos { get; set; } = new List<Procedimento>();

        //Construtor sem argumentos
        public Oficial()
        {
        }

        //Construtor com argumentos
        public Oficial(int id, string re, string digito, Posto posto, string nome, string email, FuncaoOficial status)
        {
            Id = id;
            Re = re;
            Digito = digito;
            Posto = posto;
            Nome = nome;
            Email = email;
            Status = status;
        }

        int qtdProcedimentos = 0;
        //Adicionar um Procedimento na lista de Procedimentos
        public void AddProced(Procedimento proc)
        {
            Procedimentos.Add(proc);
            qtdProcedimentos++;
        }

        //Removendo um Procedimento da lista de Procedimentos
        public void RenoveProc(Procedimento proc)
        {
            Procedimentos.Remove(proc);
            qtdProcedimentos--;
        }
        
    }
}
