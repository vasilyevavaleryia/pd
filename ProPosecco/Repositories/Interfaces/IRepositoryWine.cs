using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Models.Wine;
using System.Collections.Generic;

namespace ProProsecco.Repositories.Interfaces
{
    public interface IRepositoryWine : IRepositoryBase<Wine>
    {
        Wine GetWineById(long id);

        ICollection<Wine> GetWinesByCriterias(WineGetModelShopView model);

        void DeleteFromStocks(long id, int amount);

        void AddToStocks(long id, int amount);
    }
}
