using ProProsecco.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProProsecco.Models.Wine
{
    public class WineGetModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Taste { get; set; }

        public string ProductionCountry { get; set; }

        public int ProductionYear { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        [DisplayName("Ilość")]
        [Required(ErrorMessage = "Wpisz w pole powyżej ile win chcesz dodać do koszyka.")]
        [Range(1, 100, ErrorMessage = "Wpisz poprawną ilość (1 - 100).")]
        public int AmountCartAdd { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }
    }
}
