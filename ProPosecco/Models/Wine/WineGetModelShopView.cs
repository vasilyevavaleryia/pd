using ProProsecco.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProProsecco.Models.Wine
{
    public class WineGetModelShopView
    {
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [DisplayName("Kolor")]
        public WineColor? Color { get; set; }

        [DisplayName("Smak")]
        public WineTaste? Taste { get; set; }

        [DisplayName("Kraj produkcji")]
        public Country? ProductionCountry { get; set; }

        public ICollection<ProPosecco.Areas.Identity.Data.Entities.Wine> Wines { get; set; }
    }
}
