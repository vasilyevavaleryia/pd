namespace ProPosecco.Areas.Identity.Data.Entities
{
    public class CartItem : Entity
    {
        public int Amount { get; set; }

        public long WineId { get; set; }

        public Wine Wine { get; set; }

        public long CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
