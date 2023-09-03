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
    internal sealed class FacturaVentaService : IFacturaVentaRepository
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FacturaVentaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<FacturaVentaDTO> GetAllSaleBills(bool trackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetAllSaleBills(trackChanges);
            var facturaVentaDTO = _mapper.Map<IEnumerable<FacturaVentaDTO>>(facturaVenta);

            return facturaVentaDTO;
        }

        public FacturaVentaDTO GetSaleBill(Guid Id, bool trackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetSaleBill(Id, trackChanges);
            if(facturaVenta == null)
            {
                throw new FacturaVentaNotFoundException(Id);
            }

            var facturaVentaDTO = _mapper.Map<FacturaVentaDTO>(facturaVenta);
            return facturaVentaDTO;
        }
    }
}
