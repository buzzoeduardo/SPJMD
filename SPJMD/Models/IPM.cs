using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPJMD.Models
{
    public class IPM
    {
        public int Numero { get; set; }
        public int PrefixoOPM { get; set; }
        public DateTime AnoInstaura { get; set; }
        public string Natureza { get; set; }
        public Oficial Oficial { get; set; }
        public Investigado Investigado { get; set; }

        public IPM()
        {            
        }
        public IPM(int numero, int prefixoOPM, DateTime anoInstaura, string natureza, Oficial oficial, Investigado investigado)
        {
            Numero = numero;
            PrefixoOPM = prefixoOPM;
            AnoInstaura = anoInstaura;
            Natureza = natureza;
            Oficial = oficial;
            Investigado = investigado;
        }
    }
}
