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
    public class FacturaCompraRepository : RepositoryBase<FacturaCompraDTO>, IFacturaCompraRepository
    {
        public FacturaCompraRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<FacturaCompraDTO> GetAllBuyBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NFactura)
                .ToList();

        public FacturaCompraDTO GetBuyBill(Guid FacturaCompraId, bool trackChanges) =>
            FindByCondition(c => c.FacturaCompraId.Equals(FacturaCompraId), trackChanges)
            .SingleOrDefault();

    }
}
