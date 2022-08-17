using ProProsecco.Enums;

namespace ProProsecco.Models.Orders
{
    public class OrderGetModel
    {
        public long Id { get; set; }

        public OrderStatus Status { get; set; }
    }
}
