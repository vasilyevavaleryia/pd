using ProPosecco.Areas.Identity.Data;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Models.Wine;
using ProProsecco.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProProsecco.Repositories.Implementations
{
    public class RepositoryWine : RepositoryBase<Wine>, IRepositoryWine
    {
        public RepositoryWine(ProProseccoDbContext context) : base(context) { }

        public Wine GetWineById(long id)
        {
            return GetByCondtion(w => w.Id == id)
                .FirstOrDefault();
        }

        public ICollection<Wine> GetWinesByCriterias(WineGetModelShopView model)
        {
            if (model.Name == null &&
                model.ProductionCountry == null &&
                model.Color == null &&
                model.Taste == null)
            {
                return GetAll()
                    .ToList();
            }

            return GetByCondtion(w => (model.Name == null ? true : w.Name.Contains(model.Name)) &&
                (model.ProductionCountry == null ? true : w.ProductionCountry == model.ProductionCountry) &&
                (model.Color == null ? true : w.Color == model.Color) && 
                (model.Taste == null ? true : w.Taste == model.Taste))
                .ToList();
        }

        public void DeleteFromStocks(long id, int amount)
        {
            var wine = GetWineById(id);

            wine.Amount = wine.Amount - amount;
            Context.Update(wine);
        }

        public void AddToStocks(long id, int amount)
        {
            var wine = GetWineById(id);

            wine.Amount = wine.Amount + amount;
            Context.Update(wine);
        }

    }
}
