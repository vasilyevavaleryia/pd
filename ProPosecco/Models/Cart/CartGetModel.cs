using ProPosecco.Areas.Identity.Data.Entities;
using System.Collections.Generic;

namespace ProProsecco.Models.Carts
{
    public class CartGetModel
    {
        public long Id { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public double TotalPrice { get; set; }
    }
}
