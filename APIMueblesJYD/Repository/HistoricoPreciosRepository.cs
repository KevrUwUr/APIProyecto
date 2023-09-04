using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HistoricoPreciosRepository : RepositoryBase<HistoricoPreciosDTO>, IHistoricoPreciosRepository
    {
        public HistoricoPreciosRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<HistoricoPreciosDTO> GetAllPriceHistories(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdHistoricoPrecios)
                .ToList();

        public HistoricoPreciosDTO GetPriceHistory(int IdHistoricoPrecios, bool trackChanges) =>
            FindByCondition(c => c.IdHistoricoPrecios.Equals(IdHistoricoPrecios), trackChanges)
            .SingleOrDefault();

    }
}
