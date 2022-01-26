using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SPJMD.Models.Enums
{
    public enum TiposProcedimentos : int
    {
        [Display(Name ="IP")]
        IP = 0,
        [Display(Name = "SINDICÂNCIA")]
        Sindicancia = 1,
        [Display(Name = "IPM")]
        IPM = 2,
        [Display(Name = "APURAÇÃO PRELIMINAR")]
        Apuracao_Preliminar = 3,
        [Display(Name = "APFD")]
        Apfd = 4
    }
}
