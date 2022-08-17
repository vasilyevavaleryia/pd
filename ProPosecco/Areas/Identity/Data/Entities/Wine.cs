using ProProsecco.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProPosecco.Areas.Identity.Data.Entities
{
    public class Wine : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public WineColor Color { get; set; }

        [Required]
        public WineTaste Taste { get; set; }

        [Required]
        public Country ProductionCountry { get; set; }

        [Required]
        public int ProductionYear { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 999999.99)]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
