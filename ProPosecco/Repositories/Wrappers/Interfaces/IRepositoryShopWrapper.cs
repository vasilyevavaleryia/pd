using ProProsecco.Repositories.Interfaces;

namespace ProProsecco.Repositories.Wrappers.Interfaces
{
    public interface IRepositoryShopWrapper
    {
        IRepositoryWine Wine { get; }

        IRepositoryOrder Order { get; }

        IRepositoryCart Cart { get; }

        int Save();
    }
}
