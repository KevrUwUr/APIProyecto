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
        public MetodoPagoDTO CreatePaymentMethod(MetodoPagoForCreationDTO paymentMethod)
        {
            var metodoPagoEntity = _mapper.Map<MetodoPago>(paymentMethod);

            _repository.MetodoPago.CreatePaymentMethod(metodoPagoEntity);
            _repository.Save();

            var paymentMethodToReturn = _mapper.Map<MetodoPagoDTO>(metodoPagoEntity);
            return paymentMethodToReturn;
        }
        public IEnumerable<MetodoPagoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var paymentMethodEntities = _repository.MetodoPago.GetByIds(ids, trackChanges);
            if (ids.Count() != paymentMethodEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var companiesToReturn = _mapper.Map<IEnumerable<MetodoPagoDTO>>(paymentMethodEntities);

            return companiesToReturn;
        }
        public (IEnumerable<MetodoPagoDTO> metodoPagos, string ids) CreatePaymentMethodCollection
            (IEnumerable<MetodoPagoForCreationDTO> paymentMethodCollection)
        {
            if (paymentMethodCollection is null)
                throw new MetodoPagoCollectionBadRequest();
            var paymentMethodEntities = _mapper.Map<IEnumerable<MetodoPago>>(paymentMethodCollection);
            foreach (var paymentMethod in paymentMethodEntities)
            {
                _repository.MetodoPago.CreatePaymentMethod(paymentMethod);
            }
            _repository.Save();
            var paymentMethodCollectionToReturn =
            _mapper.Map<IEnumerable<MetodoPagoDTO>>(paymentMethodEntities);
            var ids = string.Join(",", paymentMethodCollectionToReturn.Select(c => c.IdMetodoPago));
            return (categories: paymentMethodCollectionToReturn, ids: ids);
        }
        public void DeletePaymentMethod(Guid paymentMethodId, bool trackChanges)
        {
            var paymentMethod = _repository.MetodoPago.GetPaymentMethod(paymentMethodId, trackChanges);
            if (paymentMethod == null)
                throw new MetodoPagoNotFoundException(paymentMethodId);

            _repository.MetodoPago.DeletePaymentMethod(paymentMethod);
            _repository.Save();
        }
        public void UpdatePaymentMethod(Guid paymentMethodId, MetodoPagoForUpdateDTO paymentMethodForUpdate, bool trackChanges)
        {
            var paymentMethodEntity = _repository.MetodoPago.GetPaymentMethod(paymentMethodId, trackChanges);
            if (paymentMethodEntity == null)
                throw new MetodoPagoNotFoundException(paymentMethodId);

            _mapper.Map(paymentMethodForUpdate, paymentMethodEntity);
            _repository.Save();
        }
    }
}
