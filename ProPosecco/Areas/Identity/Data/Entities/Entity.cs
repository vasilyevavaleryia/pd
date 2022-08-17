using System;

namespace ProPosecco.Areas.Identity.Data.Entities
{
    public class Entity
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
