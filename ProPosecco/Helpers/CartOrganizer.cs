using ProPosecco.Areas.Identity.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProProsecco.Helpers
{
    public class CartOrganizer
    {
        public static ICollection<CartItem> OrganizeCart(Cart cart)
        {
            if (cart == null || cart.CartItems == null)
            {
                return null;
            }

            return cart.CartItems.GroupBy(ci => ci.WineId)
                .Select(ci => new CartItem
                {
                    Wine = ci.First().Wine,
                    Cart = ci.First().Cart,
                    Amount = ci.Sum(item => item.Amount)
                })
                .ToList();
        }
    }
}
