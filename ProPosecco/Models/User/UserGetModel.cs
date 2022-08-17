using ProPosecco.Areas.Identity.Data.Entities;
using System.Collections.Generic;

namespace ProProsecco.Models.User
{
    public class UserGetModel
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string Email { get; set; }

        public ProPosecco.Areas.Identity.Data.Entities.Cart CurrentCart { get; set; }

        public ICollection<ProPosecco.Areas.Identity.Data.Entities.Cart> Carts { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
