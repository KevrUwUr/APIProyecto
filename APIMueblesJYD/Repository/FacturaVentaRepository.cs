using Contracts;
using Entities.Models;
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

        public IEnumerable<FacturaVenta> GetAllSaleBill(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdFacturaVenta)
                .ToList();

        public FacturaVenta GetSaleBill(Guid IdFacturaVenta, bool trackChanges) =>
            FindByCondition(c => c.IdFacturaVenta.Equals(IdFacturaVenta), trackChanges)
            .SingleOrDefault();

    }
}
