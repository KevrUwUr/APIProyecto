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
    public class FacturaVentaRepository : RepositoryBase<FacturaVentaDTO>, IFacturaVentaRepository
    {
        public FacturaVentaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<FacturaVentaDTO> GetAllSaleBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdFacturaVenta)
                .ToList();

        public FacturaVentaDTO GetSaleBill(int IdFacturaVenta, bool trackChanges) =>
            FindByCondition(c => c.IdFacturaVenta.Equals(IdFacturaVenta), trackChanges)
            .SingleOrDefault();

    }
}
