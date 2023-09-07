using Contracts;
using Entities.Models;
using Repository.Configuration;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DetalleFacturaCompraRepository : RepositoryBase<DetalleFacturaCompra>, IDetFacturaCompraRepository
    {
        public DetalleFacturaCompraRepository (RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<DetalleFacturaCompra> GetAllDetBuyBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.FacturaCompraId)
                .ToList();

        public DetalleFacturaCompra GetDetBuyBill(Guid FacturaCompraId, bool trackChanges) =>
            FindByCondition(c => c.FacturaCompraId.Equals(FacturaCompraId), trackChanges)
            .SingleOrDefault();
    
    }
}
