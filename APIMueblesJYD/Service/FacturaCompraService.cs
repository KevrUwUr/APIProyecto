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
    internal sealed class FacturaCompraService : IFacturaCompraService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FacturaCompraService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<FacturaCompraDTO> GetAllBuyBills(bool trackChanges)
        {
            var facturaVenta = _repository.FacturaCompra.GetAllBuyBills(trackChanges);
            var facturaVentaDTO = _mapper.Map<IEnumerable<FacturaCompraDTO>>(facturaVenta);

            return facturaVentaDTO;
        }

        public FacturaCompraDTO GetBuyBill(Guid Id, bool trackChanges)
        {
            var facturaVenta = _repository.FacturaCompra.GetBuyBill(Id, trackChanges);
            if(facturaVenta == null)
            {
                throw new FacturaCompraNotFoundException(Id);
            }

            var facturaVentaDTO = _mapper.Map<FacturaCompraDTO>(facturaVenta);
            return facturaVentaDTO;
        }
    }
}
