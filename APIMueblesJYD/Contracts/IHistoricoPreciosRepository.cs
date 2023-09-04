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
        IEnumerable<HistoricoPreciosDTO> GetAllPriceHistories(bool trackChanges);
        HistoricoPreciosDTO GetPriceHistory(int priceHistoryId, bool trackChanges);
    }
}
