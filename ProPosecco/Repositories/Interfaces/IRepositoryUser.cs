using ProPosecco.Areas.Identity.Data;
using System.Collections.Generic;

namespace ProProsecco.Repositories.Interfaces
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        IEnumerable<User> GetNormalUsers(string adminId);

        User GetUser(string id);
    }
}
