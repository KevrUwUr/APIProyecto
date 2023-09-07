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
    public class DetalleFacturaVentaRepository : RepositoryBase<DetalleFacturaVenta>, IDetFacturaVentaRepository
    {
        public DetalleFacturaVentaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<DetalleFacturaVenta> GetAllDetSaleBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.FacturaVentaId)
                .ToList();

        public DetalleFacturaVenta GetDetSaleBill(Guid FacturaVentaId, bool trackChanges) =>
            FindByCondition(c => c.FacturaVentaId.Equals(FacturaVentaId), trackChanges)
            .SingleOrDefault();
    
    }
}
