using System.ComponentModel.DataAnnotations;

namespace ProProsecco.Enums
{
    public enum WineColor
    {
        [Display(Name = "Czerwone")] Red = 0,
        [Display(Name = "Białe")] White,
        [Display(Name = "Różowe")] Rose
    }
}
