using Contracts;
using Entities.Models;
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

        public IEnumerable<DetalleFacturaVenta> GetAllDSaleBill(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.DetalleFacturaVentaID)
                .ToList();

        public DetalleFacturaVenta GetDSalesBill(Guid DetalleFacturaVentaID, bool trackChanges) =>
            FindByCondition(c => c.DetalleFacturaVentaID.Equals(DetalleFacturaVentaID), trackChanges)
            .SingleOrDefault();
    
    }
}
