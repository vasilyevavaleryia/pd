using ProProsecco.Repositories.Interfaces;

namespace ProProsecco.Repositories.Wrappers.Interfaces
{
    public interface IRepositoryCartWrapper
    {
        IRepositoryCartItem CartItem { get; }

        IRepositoryCart Cart { get; }

        IRepositoryWine Wine { get; }

        int Save();
    }
}
