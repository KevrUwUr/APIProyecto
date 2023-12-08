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

        public IEnumerable<FacturaCompra> GetAllBuyBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NFactura)
                .ToList();

        public FacturaCompra GetBuyBill(Guid FacturaCompraId, bool trackChanges) =>
            FindByCondition(c => c.FacturaCompraId.Equals(FacturaCompraId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<FacturaCompra> GetAllBuyBillsForSupplier(Guid proveedorId, bool trackChanges) =>
            FindByCondition(e => e.IdProveedor.Equals(proveedorId), trackChanges)
            .OrderBy(e => e.Proveedores)
            .ToList();

        public FacturaCompra GetBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.IdProveedor.Equals(proveedorId) && e.FacturaCompraId == (Id), trackChanges)
            .SingleOrDefault();

        public void CreateBuyBillForSupplier(Guid proveedorId, FacturaCompra facCompra)
        {
            facCompra.IdProveedor = proveedorId;
            Create(facCompra);
        }

        public void DeleteBuyBill(FacturaCompra facCompra) => Delete(facCompra);
    }
}
