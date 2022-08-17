using Microsoft.AspNetCore.Identity;
using ProPosecco.Areas.Identity.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProPosecco.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        public long UserDetailsId { get; set; }

        [Required]
        public virtual UserDetails UserDetails { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
