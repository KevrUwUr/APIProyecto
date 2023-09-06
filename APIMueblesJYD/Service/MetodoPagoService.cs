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
    }
}
