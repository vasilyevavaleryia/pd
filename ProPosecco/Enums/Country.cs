using System.ComponentModel.DataAnnotations;

namespace ProProsecco.Enums
{
    public enum Country
    {
        [Display(Name = "Hiszpania")] Spain = 0,
        [Display(Name = "Włochy")] Italy,
        [Display(Name = "RPA")] RPA,
        [Display(Name = "Francja")] France,
        [Display(Name = "USA")] USA,
        [Display(Name = "Bułgaria")] Bulgaria,
        [Display(Name = "Australia")] Australia,
        [Display(Name = "Argentyna")] Argentina,
        [Display(Name = "Portugalia")] Portugal,
        [Display(Name = "Armenia")] Armenia,
        [Display(Name = "Nowa Zelandia")] NewZeland,
        [Display(Name = "Mołdawia")] Moldova,
        [Display(Name = "Gruzja")] Georgia,
        [Display(Name = "Chile")] Chile,
    }
}
