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
    public class DetalleFacturaVentaRepository : RepositoryBase<DFacturaVentaDTO>, IDetFacturaVentaRepository
    {
        public DetalleFacturaVentaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<DFacturaVentaDTO> GetAllDSaleBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdFacturaVenta)
                .ToList();

        public DFacturaVentaDTO GetDetSaleBill(int IdFacturaVenta, bool trackChanges) =>
            FindByCondition(c => c.IdFacturaVenta.Equals(IdFacturaVenta), trackChanges)
            .SingleOrDefault();
    
    }
}
