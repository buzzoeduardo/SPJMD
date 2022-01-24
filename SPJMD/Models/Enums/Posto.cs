using System.ComponentModel.DataAnnotations;


namespace SPJMD.Models.Enums
{
    public enum Posto
    {
        [Display(Name = "Cel PM")]
        Cel = 0,

        [Display(Name = "Ten Cel PM")]
        Ten_Cel = 1,

        [Display(Name = "Maj PM")]
        Maj = 2,

        [Display(Name = "Cap PM")]
        Cap = 3,

        [Display(Name = "1º Ten PM")]
        PrimTen = 4,

        [Display(Name = "2º Ten PM")]
        SegTen = 5
    }
}

