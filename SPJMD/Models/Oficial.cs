using SPJMD.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SPJMD.Models
{
    public class Oficial
    {
        public int Re { get; set; }

        [Display(Name = "DIG")]
        public string Digito { get; set; }


        public Posto Posto { get; set; }
        public string Nome { get; set; }

        [Display(Name = "E-MAIL")]
        public string Email { get; set; }

       
        public Oficial()
        {
        }

        public Oficial(int re, string digito, Posto posto, string nome, string email)
        {
            Re = re;
            Digito = digito;
            Posto = posto;
            Nome = nome;
            Email = email;
           
        }
    }
}
