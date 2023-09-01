using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHistoricoPreciosRepository
    {
        IEnumerable<HistoricoPrecios> GetAllPriceHistory(bool trackChanges);
    }
}
