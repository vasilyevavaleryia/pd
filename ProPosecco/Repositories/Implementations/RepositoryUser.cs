using Microsoft.EntityFrameworkCore;
using ProPosecco.Areas.Identity.Data;
using ProProsecco.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProProsecco.Repositories.Implementations
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(ProProseccoDbContext context) : base(context) { }

        public IEnumerable<User> GetNormalUsers(string adminId)
        {
            return GetByCondtion(u => u.Id != adminId)
                .Include(u => u.UserDetails)
                .ToList();
        }

        public User GetUser(string id)
        {
            var user = GetByCondtion(u => u.Id == id)
                .Include(u => u.UserDetails)
                .Include(u => u.Carts)
                .ThenInclude(c => c.Order)
                .Include(u => u.Carts)
                .ThenInclude(c => c.CartItems)
                .ThenInclude(w => w.Wine)
                .FirstOrDefault();

            return user;
        }
    }
}
