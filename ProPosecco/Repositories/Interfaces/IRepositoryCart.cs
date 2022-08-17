using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Models.Wine;

namespace ProProsecco.Repositories.Interfaces
{
    public interface IRepositoryCart : IRepositoryBase<Cart>
    {
        Cart GetCartById(long id, string userId);

        Cart GetUserCartWithItems(string userId);

        Cart GetOrCreateUserCart(string userId);

        decimal GetCartValue(long id);
    }
}
