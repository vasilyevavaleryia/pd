using ProProsecco.Repositories.Interfaces;

namespace ProProsecco.Repositories.Wrappers.Interfaces
{
    public interface IRepositoryAdministratorWrapper
    {
        IRepositoryUser User { get; }

        IRepositoryWine Wine { get; }

        IRepositoryOrder Order { get; }

        int Save();
    }
}
