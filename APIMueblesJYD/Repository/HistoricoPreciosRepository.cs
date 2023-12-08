using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HistoricoPreciosRepository : RepositoryBase<HistoricoPrecios>, IHistoricoPreciosRepository
    {
        public HistoricoPreciosRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<HistoricoPrecios> GetAllPriceHistories(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdHistoricoPrecios)
                .ToList();

        public HistoricoPrecios GetPriceHistory(Guid IdHistoricoPrecios, bool trackChanges) =>
            FindByCondition(c => c.IdHistoricoPrecios.Equals(IdHistoricoPrecios), trackChanges)
            .SingleOrDefault();

        public IEnumerable<HistoricoPrecios> GetAllPriceHistoriesForProduct(Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.ProductoId.Equals(productoId), trackChanges)
            .OrderBy(e => e.Producto)
            .ToList();

        public HistoricoPrecios GetPriceHistoryForProduct(Guid productoId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.ProductoId.Equals(productoId) && e.IdHistoricoPrecios == (Id), trackChanges)
            .SingleOrDefault();

        public void CreatePriceHistoryForProduct(Guid productoId, HistoricoPrecios historicoPrecio)
        {
            historicoPrecio.ProductoId = productoId;
            Create(historicoPrecio);
        }

        public void DeletePriceHistory(HistoricoPrecios historicoPrecio) => Delete(historicoPrecio);
    }
}
