using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHistoricoPreciosRepository
    {
        IEnumerable<HistoricoPrecios> GetAllPriceHistories(bool trackChanges);
        HistoricoPrecios GetPriceHistory(Guid priceHistoryId, bool trackChanges);
        IEnumerable<HistoricoPrecios> GetAllPriceHistoriesForProduct(Guid productoId, bool trackChanges);
        HistoricoPrecios GetPriceHistoryForProduct(Guid productoId, Guid Id, bool trackChanges);
        void CreatePriceHistoryForProduct(Guid productoId, HistoricoPrecios historicoPrecio);
        void DeletePriceHistory(HistoricoPrecios historicoPrecio);
    }
}
