using System.Collections.Generic;


namespace SPJMD.Models.ViewModels
{
    public class ModeloPostGrad
    {
        public Policial Policial { get; set; }
        public IList<Enums.PostGrad> PostGrad { get; set; }
        public ICollection<Enums.QualificacaoEnvolvido> Qualifica { get; set; }
        public ErrorViewModel Erro { get; set; }
    }
}
