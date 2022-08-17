using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Models.Wine;

namespace ProProsecco.Repositories.Interfaces
{
    public interface IRepositoryCartItem : IRepositoryBase<CartItem>
    {
        int GetCartItemAmount(Cart cart, long wineId);

        void AddToCart(WineGetModel model, Cart cart);

        void DeleteFromCart(Cart cart, long wineId);
    }
}
