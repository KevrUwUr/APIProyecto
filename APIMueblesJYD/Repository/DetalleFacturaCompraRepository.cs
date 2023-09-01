using Contracts;
using Entities.Models;
using Repository.Configuration;
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

        public IEnumerable<DetalleFacturaCompra> GetAllDBuyBill(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdFacturaCompra)
                .ToList();

        public DetalleFacturaCompra GetDBuyBill(Guid IdFacturaCompra, bool trackChanges) =>
            FindByCondition(c => c.IdFacturaCompra.Equals(IdFacturaCompra), trackChanges)
            .SingleOrDefault();
    
    }
}
