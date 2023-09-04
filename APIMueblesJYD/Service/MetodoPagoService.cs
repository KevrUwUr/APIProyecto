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
    internal sealed class MetodoPagoService : IMetodoPagoRepository
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

        public IEnumerable<MetodoPagoDTO> GetAllPayMethods(bool trackChanges)
        {
            var metodoPago = _repository.MetodoPago.GetAllPayMethods(trackChanges);
            var metodoPagoDTO = _mapper.Map<IEnumerable<MetodoPagoDTO>>(metodoPago);

            return metodoPagoDTO;
        }

        public MetodoPagoDTO GetPayMethod(int Id, bool trackChanges)
        {
            var metodoPago = _repository.MetodoPago.GetPayMethod(Id, trackChanges);
            if(metodoPago == null)
            {
                throw new MetodoPagoNotFoundException(Id);
            }

            var metodoPagoDTO = _mapper.Map<MetodoPagoDTO>(metodoPago);
            return metodoPagoDTO;
        }
    }
}
