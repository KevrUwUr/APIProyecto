using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FacturaCompraRepository : RepositoryBase<FacturaCompra>, IFacturaCompraRepository
    {
        public FacturaCompraRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<FacturaCompra> GetAllBuyBill(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NFactura)
                .ToList();

        public FacturaCompra GetBuyBill(Guid IdFacturaCompra, bool trackChanges) =>
            FindByCondition(c => c.IdFacturaCompra.Equals(IdFacturaCompra), trackChanges)
            .SingleOrDefault();

    }
}
