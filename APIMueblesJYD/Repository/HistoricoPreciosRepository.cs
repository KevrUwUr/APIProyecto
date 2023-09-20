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

    }
}
