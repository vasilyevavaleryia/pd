using ProPosecco.Areas.Identity.Data;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Enums;
using System.Collections.Generic;

namespace ProProsecco.Repositories.Interfaces
{
    public interface IRepositoryOrder : IRepositoryBase<Order>
    {
        void Buy(long cartId, string userId, decimal totalPrice);

        void ChangeStatus(long id, OrderStatus status);
    }
}
