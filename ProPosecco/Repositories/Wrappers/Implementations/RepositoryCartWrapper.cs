using ProPosecco.Areas.Identity.Data;
using ProProsecco.Repositories.Implementations;
using ProProsecco.Repositories.Interfaces;
using ProProsecco.Repositories.Wrappers.Interfaces;

namespace ProProsecco.Repositories.Wrappers.Implementations
{
    public class RepositoryCartWrapper : IRepositoryCartWrapper
    {
        private readonly ProProseccoDbContext _context;

        private IRepositoryCartItem _cartItem;

        private IRepositoryCart _cart;

        private IRepositoryWine _wine;

        public IRepositoryCartItem CartItem
        {
            get
            {
                if (_cartItem == null)
                {
                    _cartItem = new RepositoryCartItem(_context);
                }

                return _cartItem;
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

        public RepositoryCartWrapper(ProProseccoDbContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
