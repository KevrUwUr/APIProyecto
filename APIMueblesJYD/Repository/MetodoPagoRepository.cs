using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MetodoPagoRepository : RepositoryBase<MetodoPago>, IMetodoPagoRepository
    {
        public MetodoPagoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<MetodoPago> GetAllPaymentMethods(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NombrePlataforma)
                .ToList();

        public MetodoPago GetPaymentMethod(Guid IdMetodoPago, bool trackChanges) =>
            FindByCondition(c => c.IdMetodoPago.Equals(IdMetodoPago), trackChanges)
            .SingleOrDefault();

        public IEnumerable<MetodoPago> GetAllPaymentMethodsForSaleBill(Guid facVentaId, bool trackChanges) =>
            FindByCondition(e => e.FacturaVentaId.Equals(facVentaId), trackChanges)
            .OrderBy(e => e.FacturaVenta)
            .ToList();

        public MetodoPago GetPaymentMethodForSaleBill(Guid facVentaId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.FacturaVentaId.Equals(facVentaId) && e.IdMetodoPago == (Id), trackChanges)
            .SingleOrDefault();

        public void CreatePaymentMethodForSaleBill(Guid facturaVentaId, MetodoPago metodoPago)
        {
            metodoPago.IdMetodoPago = facturaVentaId;
            Create(metodoPago);
        }

        public void DeletePaymentMethod(MetodoPago metodoPago) => Delete(metodoPago);
    }
}
