using ProProsecco.Enums;
using ProProsecco.Helpers.Validators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProProsecco.Models.Wine
{
    public class WineUpdateModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [DisplayName("Kolor")]
        public WineColor Color { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [DisplayName("Smak")]
        public WineTaste Taste { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [DisplayName("Kraj produkcji")]
        public Country ProductionCountry { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [DisplayName("Rok produkcji")]
        [RangeAttributeUntilCurrentYear(1900, ErrorMessage = "Zakres lat: 1900 - bieżący rok!")]
        public int ProductionYear { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Cena musi składać się z liczby, z dwoma cyframi po kropce!")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [DisplayName("Cena")]
        [Range(1, 999999.99, ErrorMessage = "Minimalna cena to {1} zł, maxymalna to {2} zł!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!")]
        [DisplayName("Dostępna ilość")]
        [Range(0, 10000, ErrorMessage = "Minimalna ilość to {1}, maxymalna to {2}!")]
        public int Amount { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Zdjęcie")]
        public byte[] Photo { get; set; }
    }
}
