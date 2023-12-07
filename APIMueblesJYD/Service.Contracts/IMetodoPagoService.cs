using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMetodoPagoService
    {
        IEnumerable<MetodoPagoDTO> GetAllPaymentMethods(bool trackChanges);
        MetodoPagoDTO GetPaymentMethod(Guid Id, bool trackChanges);
        IEnumerable<MetodoPagoDTO> GetAllPaymentMethodsForSaleBill(Guid facturaVentaId, bool trackChanges);
        MetodoPagoDTO GetPaymentMethodForSaleBill(Guid facturaVentaId, Guid Id, bool trackChanges);
        MetodoPagoDTO CreatePaymentMethodForSaleBill(Guid facturaVentaId, MetodoPagoForCreationDTO paymentMethod, bool trackChanges);
        void DeletePaymentMethodForSaleBill(Guid facturaVentaId, Guid paymentMethodId, bool trackChanges);
        void UpdatePaymentMethodForSaleBill(Guid facturaVentaId, Guid paymentMethodId, 
            MetodoPagoForUpdateDTO paymentMethodForUpdate, bool facVentaTrackChanges, bool metPagoTrackChanges);
        (MetodoPagoForUpdateDTO metPagoToPatch, MetodoPago metPagoEntity) GetMetodoPagoForPatch
            (Guid facturaVentaId, Guid Id, bool facturaVentaTrackChanges, bool metPagoTrackChanges);
        void SaveChangesForPatch(MetodoPagoForUpdateDTO metPagoToPatch, MetodoPago metPagoEntity);
    }
}
