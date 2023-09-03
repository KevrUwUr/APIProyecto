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
    internal sealed class DetFacturaCompraService : IDetFacturaCompraRepository
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DetFacturaCompraService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<DFacturaCompraDTO> GetAllDetBuyBills(bool trackChanges)
        {
            var dFacturaCompra = _repository.DetFacturaCompra.GetAllDetBuyBills(trackChanges);
            var dFacturaCompraDTO = _mapper.Map<IEnumerable<DFacturaCompraDTO>>(dFacturaCompra);

            return dFacturaCompraDTO;
        }

        public DFacturaCompraDTO GetDetBuyBill(Guid Id, bool trackChanges)
        {
            var dFacturaCompra = _repository.DetFacturaCompra.GetDetBuyBill(Id, trackChanges);
            if(dFacturaCompra == null)
            {
                throw new DetalleFacturaCompraNotFoundException(Id);
            }

            var dFacturaCompraDTO = _mapper.Map<DFacturaCompraDTO>(dFacturaCompra);
            return dFacturaCompraDTO;
        }

    }
}
