using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ProductoService : IProductoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProductoDTO> GetAllProducts(bool trackChanges)
        {
            var producto = _repository.Producto.GetAllProducts(trackChanges);
            var productoDTO = _mapper.Map<IEnumerable<ProductoDTO>>(producto);

            return productoDTO;
        }

        public ProductoDTO GetProduct(Guid Id, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(Id, trackChanges);
            if(producto == null)
            {
                throw new ProductoNotFoundException(Id);
            }

            var productoDTO = _mapper.Map<ProductoDTO>(producto);
            return productoDTO;
        }
    }
}
