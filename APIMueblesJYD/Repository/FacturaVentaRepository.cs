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
    public class FacturaVentaRepository : RepositoryBase<FacturaVenta>, IFacturaVentaRepository
    {
        public FacturaVentaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<FacturaVenta> GetAllSaleBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.FacturaVentaId)
                .ToList();

        public FacturaVenta GetSaleBill(Guid FacturaVentaId, bool trackChanges) =>
            FindByCondition(c => c.FacturaVentaId.Equals(FacturaVentaId), trackChanges)
            .SingleOrDefault();

    }
}
