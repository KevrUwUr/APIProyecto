using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class MetodoPagoService : IMetodoPagoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MetodoPagoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<MetodoPagoDTO> GetAllPaymentMethods(bool trackChanges)
        {
            var metodoPago = _repository.MetodoPago.GetAllPaymentMethods(trackChanges);
            var metodoPagoDTO = _mapper.Map<IEnumerable<MetodoPagoDTO>>(metodoPago);

            return metodoPagoDTO;
        }

        public MetodoPagoDTO GetPaymentMethod(Guid Id, bool trackChanges)
        {
            var metodoPago = _repository.MetodoPago.GetPaymentMethod(Id, trackChanges);
            if(metodoPago == null)
            {
                throw new MetodoPagoNotFoundException(Id);
            }

            var metodoPagoDTO = _mapper.Map<MetodoPagoDTO>(metodoPago);
            return metodoPagoDTO;
        }

        public IEnumerable<MetodoPagoDTO> GetAllPaymentMethodsForSaleBill(Guid facturaVentaId, bool trackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetSaleBill(facturaVentaId, trackChanges);

            if (facturaVenta is null)
            {
                throw new MetodoPagoNotFoundException(facturaVentaId);
            }
            var metPagosFromDb = _repository.MetodoPago.GetAllPaymentMethodsForSaleBill(facturaVentaId, trackChanges);
            var metPagosDTO = _mapper.Map<IEnumerable<MetodoPagoDTO>>(metPagosFromDb);

            return metPagosDTO;
        }

        public MetodoPagoDTO GetPaymentMethodForSaleBill(Guid facturaVentaId, Guid Id, bool trackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetSaleBill(facturaVentaId, trackChanges);
            if (facturaVenta is null)
            {
                throw new FacturaVentaNotFoundException(facturaVentaId);
            }
            var facVentaDb = _repository.MetodoPago.GetPaymentMethodForSaleBill(facturaVentaId, Id, trackChanges);
            if (facVentaDb is null)
            {
                throw new MetodoPagoNotFoundException(Id);
            }
            var facVenta = _mapper.Map<MetodoPagoDTO>(facVentaDb);
            return facVenta;
        }

        public MetodoPagoDTO CreatePaymentMethodForSaleBill(Guid facturaVentaId, MetodoPagoForCreationDTO paymentMethod, bool trackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetSaleBill(facturaVentaId, trackChanges);
            if (facturaVenta is null)
                throw new FacturaVentaNotFoundException(facturaVentaId);

            var metodoPagoEntity = _mapper.Map<MetodoPago>(paymentMethod);

            _repository.MetodoPago.CreatePaymentMethodForSaleBill(facturaVentaId, metodoPagoEntity);
            _repository.Save();

            var paymentMethodToReturn = _mapper.Map<MetodoPagoDTO>(metodoPagoEntity);
            return paymentMethodToReturn;
        }

        public void DeletePaymentMethodForSaleBill(Guid facturaVentaId, Guid paymentMethodId, bool trackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetSaleBill(facturaVentaId, trackChanges);
            if (facturaVenta is null)
                throw new FacturaVentaNotFoundException(facturaVentaId);

            var paymentMethod = _repository.MetodoPago.GetPaymentMethodForSaleBill(facturaVentaId, paymentMethodId, 
                trackChanges);
            if (paymentMethod == null)
                throw new MetodoPagoNotFoundException(paymentMethodId);

            _repository.MetodoPago.DeletePaymentMethod(paymentMethod);
            _repository.Save();
        }

        public void UpdatePaymentMethodForSaleBill(Guid facturaVentaId, Guid paymentMethodId, MetodoPagoForUpdateDTO paymentMethodForUpdate, bool facVentaTrackChanges, bool metPagoTrackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetSaleBill(facturaVentaId, facVentaTrackChanges);
            if (facturaVenta is null)
            {
                throw new FacturaVentaNotFoundException(paymentMethodId);
            }

            var paymentMethodEntity = _repository.MetodoPago.GetPaymentMethodForSaleBill(facturaVentaId,paymentMethodId, metPagoTrackChanges);
            if (paymentMethodEntity is null)
            {
                throw new MetodoPagoNotFoundException(paymentMethodId);
            }

            _mapper.Map(paymentMethodForUpdate, paymentMethodEntity);
            _repository.Save();
        }

        public (MetodoPagoForUpdateDTO metPagoToPatch, MetodoPago metPagoEntity) GetMetodoPagoForPatch(Guid facturaVentaId, Guid id, bool facVentaTrackChanges, bool metodoPagoTrackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetSaleBill(facturaVentaId, metodoPagoTrackChanges);
            if (facturaVenta is null)
                throw new FacturaVentaNotFoundException(facturaVentaId);

            var metodoPagoEntity = _repository.MetodoPago.GetPaymentMethodForSaleBill(facturaVentaId, id, metodoPagoTrackChanges);

            if (metodoPagoEntity is null)
                throw new MetodoPagoNotFoundException(facturaVentaId);

            var metodoPagoToPatch = _mapper.Map<MetodoPagoForUpdateDTO>(metodoPagoEntity);
            return (metodoPagoToPatch, metodoPagoEntity);
        }

        public void SaveChangesForPatch(MetodoPagoForUpdateDTO metodoPagoToPatch, MetodoPago metodoPagoEntity)
        {
            _mapper.Map(metodoPagoToPatch, metodoPagoEntity);
            _repository.Save();
        }
    }
}
