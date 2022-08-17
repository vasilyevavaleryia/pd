using ProPosecco.Areas.Identity.Data;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Models.Wine;
using ProProsecco.Repositories.Interfaces;
using System;
using System.Linq;

namespace ProProsecco.Repositories.Implementations
{
    public class RepositoryCartItem : RepositoryBase<CartItem>, IRepositoryCartItem
    {
        public RepositoryCartItem(ProProseccoDbContext context) : base(context) { }

        public int GetCartItemAmount(Cart cart, long wineId)
        {
            return GetByCondtion(ci => ci.WineId == wineId && ci.CartId == cart.Id)
                .Sum(ci => ci.Amount);
        }

        public void AddToCart(WineGetModel model, Cart cart)
        {
            cart.CartItems.Add(new CartItem()
            {
                Amount = model.AmountCartAdd,
                WineId = model.Id,
                CartId = cart.Id,
                CreatedAt = DateTime.Now
            });

            Context.Carts.Update(cart);
        }

        public void DeleteFromCart(Cart cart, long wineId)
        {
            var itemsToDelete = GetByCondtion(ci => ci.WineId == wineId && ci.CartId == cart.Id)
                .ToList();

            Context.CartItems.RemoveRange(itemsToDelete);
        }
    }
}
