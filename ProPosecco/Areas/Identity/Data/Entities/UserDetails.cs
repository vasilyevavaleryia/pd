using System.ComponentModel.DataAnnotations;

namespace ProPosecco.Areas.Identity.Data.Entities
{
    public class UserDetails : Entity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
