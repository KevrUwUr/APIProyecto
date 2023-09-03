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

        public IEnumerable<UsuarioDTO> GetAllProductLoses(bool trackChanges)
        {
            var perdidaProducto = _repository.PerdidaProducto.GetAllProductLoses(trackChanges);
            var perdidaProductoDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(perdidaProducto);

            return perdidaProductoDTO;
        }

        public UsuarioDTO GetProductLose(Guid Id, bool trackChanges)
        {
            var perdidaProducto = _repository.PerdidaProducto.GetProductLose(Id, trackChanges);
            if(perdidaProducto == null)
            {
                throw new PerdidaProductoNotFoundException(Id);
            }

            var perdidaProductoDTO = _mapper.Map<UsuarioDTO>(perdidaProducto);
            return perdidaProductoDTO;
        }
    }
}
