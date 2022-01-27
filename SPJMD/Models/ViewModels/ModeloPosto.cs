using System.Collections.Generic;


namespace SPJMD.Models.ViewModels
{
    public class ModeloPosto
    {
        public Oficial Oficial { get; set; }
        public IList<Enums.Posto> Posto { get; set; }
        public ICollection<Enums.FuncaoOficial> FuncaoOficial { get; set; }
    }
}

