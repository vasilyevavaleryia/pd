using ProPosecco.Areas.Identity.Data;
using ProProsecco.Repositories.Implementations;
using ProProsecco.Repositories.Interfaces;
using ProProsecco.Repositories.Wrappers.Interfaces;

namespace ProProsecco.Repositories.Wrappers.Implementations
{
    public class RepositoryAdministratorWrapper : IRepositoryAdministratorWrapper
    {
        private readonly ProProseccoDbContext _context;

        private IRepositoryUser _user;

        private IRepositoryWine _wine;

        private IRepositoryOrder _order;

        public IRepositoryUser User
        {
            get
            {
                if (_user == null)
                {
                    _user = new RepositoryUser(_context);
                }

                return _user;
            }
        }

        public IRepositoryWine Wine
        {
            get
            {
                if (_wine == null)
                {
                    _wine = new RepositoryWine(_context);
                }

                return _wine;
            }
        }

        public IRepositoryOrder Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new RepositoryOrder(_context);
                }

                return _order;
            }
        }

        public RepositoryAdministratorWrapper(ProProseccoDbContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
