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
        HistoricoPreciosDTO GetPriceHistory(int Id, bool trackChanges);
    }
}
