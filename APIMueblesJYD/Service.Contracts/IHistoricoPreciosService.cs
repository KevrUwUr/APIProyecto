using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IHistoricoPreciosService
    {
        IEnumerable<HistoricoPreciosDTO> GetAllPriceHistories(bool trackChanges);
        HistoricoPreciosDTO GetPriceHistory(Guid Id, bool trackChanges);
        IEnumerable<HistoricoPreciosDTO> GetAllPriceHistoriesForProduct(Guid productoId, bool trackChanges);
        HistoricoPreciosDTO GetPriceHistoryForProduct(Guid productoId, Guid Id, bool trackChanges);
        HistoricoPreciosDTO CreatePriceHistoryForProduct(Guid productoId, HistoricoPreciosForCreationDTO priceHistory, bool trackChanges);
        void DeletePriceHistoryForProduct(Guid productoId, Guid priceHistoryId, bool trackChanges);
        void UpdatePriceHistoryForProduct(Guid productoId, Guid priceHistoryId,
            HistoricoPreciosForUpdateDTO priceHistoryForUpdate, bool productoTrackChanges, bool histPreciosTrackChanges);
        (HistoricoPreciosForUpdateDTO histPreciosToPatch, HistoricoPrecios histPreciosEntity) GetHistoricoPreciosForPatch
            (Guid productoId, Guid Id, bool productoTrackChanges, bool histPreciosTrackChanges);
        void SaveChangesForPatch(HistoricoPreciosForUpdateDTO histPreciosToPatch, HistoricoPrecios histPreciosEntity);
    }
}
