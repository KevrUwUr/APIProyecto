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
        MetodoPagoDTO CreatePaymentMethod(MetodoPagoForCreationDTO paymentMethod);
        IEnumerable<MetodoPagoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<MetodoPagoDTO> metodoPagos, string ids) CreatePaymentMethodCollection
            (IEnumerable<MetodoPagoForCreationDTO> paymentMethodCollection);
        void DeletePaymentMethod(Guid paymentMethodId, bool trackChanges);
        void UpdatePaymentMethod(Guid paymentMethodId, MetodoPagoForUpdateDTO paymentMethodForUpdate, bool trackChanges);
    }
}
