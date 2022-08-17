using ProPosecco.Areas.Identity.Data;
using ProProsecco.Repositories.Implementations;
using ProProsecco.Repositories.Interfaces;
using ProProsecco.Repositories.Wrappers.Interfaces;

namespace ProProsecco.Repositories.Wrappers.Implementations
{
    public class RepositoryShopWrapper : IRepositoryShopWrapper
    {
        private IRepositoryWine _wine;

        private IRepositoryOrder _order;

        private IRepositoryCart _cart;

        private readonly ProProseccoDbContext _context;

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

        public IRepositoryCart Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new RepositoryCart(_context);
                }

                return _cart;
            }
        }

        public RepositoryShopWrapper(ProProseccoDbContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
