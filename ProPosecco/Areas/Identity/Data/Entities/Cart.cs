using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProPosecco.Areas.Identity.Data.Entities
{
    public class Cart : Entity
    {
        public bool IsUsed { get; set; }

        [Required]
        public User User { get; set; }

        public string UserId { get; set; }

        public long OrderId { get; set; }

        [Required]
        public Order Order { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

    }
}
