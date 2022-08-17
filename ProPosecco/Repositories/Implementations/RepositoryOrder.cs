using Microsoft.EntityFrameworkCore;
using ProPosecco.Areas.Identity.Data;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Enums;
using ProProsecco.Repositories.Interfaces;
using System;
using System.Linq;

namespace ProProsecco.Repositories.Implementations
{
    public class RepositoryOrder : RepositoryBase<Order>, IRepositoryOrder
    {
        public RepositoryOrder(ProProseccoDbContext context) : base(context) { }

        public void Buy(long cartId, string userId, decimal totalPrice)
        {
            var order = GetByCondtion(o => o.Id == cartId && o.Cart.UserId == userId)
                .Include(o => o.Cart)
                .FirstOrDefault();

            order.CreatedAt = DateTime.Now;
            order.IsPaid = true;
            order.Total = totalPrice;
            order.Cart.IsUsed = true;
            order.Status = OrderStatus.InProgress;

            Context.Orders.Update(order);
        }

        public void ChangeStatus(long id, OrderStatus status)
        {
            var order = GetByCondtion(o => o.Id == id)
                .FirstOrDefault();

            order.Status = status;

            Update(order);
            Save();
        }
    }
}
