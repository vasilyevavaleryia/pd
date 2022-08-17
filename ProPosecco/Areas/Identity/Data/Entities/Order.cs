using ProProsecco.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProPosecco.Areas.Identity.Data.Entities
{
    public class Order : Entity
    {
        [Required]
        public decimal Total { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        [Required]
        [DefaultValue(0)]
        public OrderStatus Status { get; set; }

        [Required]
        public virtual Cart Cart { get; set; }
    }
}
