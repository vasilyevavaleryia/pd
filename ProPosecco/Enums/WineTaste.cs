using System.ComponentModel.DataAnnotations;

namespace ProProsecco.Enums
{
    public enum WineTaste
    {
        [Display(Name = "Wytrawne")] Dry = 0,
        [Display(Name = "Półwytrawne")] SemiDry,
        [Display(Name = "Półsłodkie")] SemiSweet,
        [Display(Name = "Słodkie")] Sweet
    }
}
