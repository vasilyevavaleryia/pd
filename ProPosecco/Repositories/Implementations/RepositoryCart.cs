using Microsoft.EntityFrameworkCore;
using ProPosecco.Areas.Identity.Data;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Models.Wine;
using ProProsecco.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProProsecco.Repositories.Implementations
{
    public class RepositoryCart : RepositoryBase<Cart>, IRepositoryCart
    {
        public RepositoryCart(ProProseccoDbContext context) : base(context) { }

        public Cart GetCartById(long id, string userId)
        {
            return GetByCondtion(c => c.Id == id && c.UserId == userId)
                .FirstOrDefault();
        }

        public Cart GetUserCartWithItems(string userId)
        {
            return GetByCondtion(c => c.UserId == userId && !c.IsUsed)
                     .Include(c => c.CartItems)
                     .ThenInclude(ci => ci.Wine)
                     .OrderBy(c => c.Id)
                     .LastOrDefault();
        }

        public Cart GetOrCreateUserCart(string userId)
        {
            var cart = GetByCondtion(c => c.UserId == userId && !c.IsUsed)
                .Include(c => c.CartItems)
                .OrderBy(c => c.Id)
                .LastOrDefault();

            if (cart == null)
            {
                cart = new Cart()
                {
                    Order = new Order(),
                    UserId = userId,
                    CartItems = new List<CartItem>(),
                    CreatedAt = DateTime.Now
                };

                Create(cart);
                Save();
            }

            return cart;
        }

        public decimal GetCartValue(long id)
        {
            var cart = GetByCondtion(c => c.Id == id)
                     .Include(c => c.CartItems)
                     .ThenInclude(ci => ci.Wine)
                     .OrderBy(c => c.Id)
                     .LastOrDefault();

            return cart.CartItems
                .Sum(ci => ci.Amount * ci.Wine.Price);
        }
    }
}
