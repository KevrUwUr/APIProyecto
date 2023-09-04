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
    internal sealed class PerdidaProductoService : IPerdidaProductoRepository
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PerdidaProductoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<PerdidaProductoDTO> GetAllProductLoses(bool trackChanges)
        {
            var perdidaProducto = _repository.PerdidaProducto.GetAllProductLoses(trackChanges);
            var perdidaProductoDTO = _mapper.Map<IEnumerable<PerdidaProductoDTO>>(perdidaProducto);

            return perdidaProductoDTO;
        }

        public PerdidaProductoDTO GetProductLose(int Id, bool trackChanges)
        {
            var perdidaProducto = _repository.PerdidaProducto.GetProductLose(Id, trackChanges);
            if(perdidaProducto == null)
            {
                throw new PerdidaProductoNotFoundException(Id);
            }

            var perdidaProductoDTO = _mapper.Map<PerdidaProductoDTO>(perdidaProducto);
            return perdidaProductoDTO;
        }
    }
}
