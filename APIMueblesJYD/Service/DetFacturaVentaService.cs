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
    internal sealed class DetFacturaVentaService : IDetFacturaVentaRepository
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DetFacturaVentaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<DFacturaVentaDTO> GetAllDSaleBills(bool trackChanges)
        {
            var dFacturaCompra = _repository.DetFacturaVenta.GetAllDSaleBills(trackChanges);
            var DFacturaVentaDTO = _mapper.Map<IEnumerable<DFacturaVentaDTO>>(dFacturaCompra);

            return DFacturaVentaDTO;
        }

        public DFacturaVentaDTO GetDetSaleBill(int Id, bool trackChanges)
        {
            var dFacturaCompra = _repository.DetFacturaVenta.GetDetSaleBill(Id, trackChanges);
            if(dFacturaCompra == null)
            {
                throw new DetalleFacturaVentaNotFoundException(Id);
            }

            var DFacturaVentaDTO = _mapper.Map<DFacturaVentaDTO>(dFacturaCompra);
            return DFacturaVentaDTO;
        }
    }
}
