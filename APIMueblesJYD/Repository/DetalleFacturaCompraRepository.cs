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

        public IEnumerable<DetalleFacturaCompra> GetAllDetBuyBillsByBuyBill(Guid facturaCompraId, bool trackChanges) =>
            FindByCondition(e => e.FacturaCompraId.Equals(facturaCompraId), trackChanges)
            .OrderBy(e => e.FacturaCompra)
            .ToList();


        public IEnumerable<DetalleFacturaCompra> GetAllDetBuyBillsByBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.FacturaCompraId.Equals(facturaCompraId) && e.ProductoId == (productoId), trackChanges)
            .OrderBy(e => e.FacturaCompra)
            .ToList();
        public DetalleFacturaCompra GetDetBuyBillByBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.FacturaCompraId.Equals(facturaCompraId) && e.ProductoId == (productoId), trackChanges)
            .SingleOrDefault();


        public void CreateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DetalleFacturaCompra detalleFacturaCompra)
        {
            detalleFacturaCompra.FacturaCompraId = facturaCompraId;
            detalleFacturaCompra.ProductoId = productoId;
            Create(detalleFacturaCompra);
        }

        public void DeleteDetBuyBill(DetalleFacturaCompra detalleFacturaCompra) => Delete(detalleFacturaCompra);

        public IEnumerable<DetalleFacturaCompra> GetAllDetBuyBillsByProduct(Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.ProductoId.Equals(productoId), trackChanges)
            .OrderBy(e => e.FacturaCompra)
            .ToList();

    }
}
