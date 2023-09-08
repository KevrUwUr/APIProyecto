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
    internal sealed class PerdidaProductoService : IPerdidaProductoService
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

        public IEnumerable<PerdidaProductoDTO> GetAllLoseProducts(bool trackChanges)
        {
            var perdidaProducto = _repository.PerdidaProducto.GetAllProductLoses(trackChanges);
            var perdidaProductoDTO = _mapper.Map<IEnumerable<PerdidaProductoDTO>>(perdidaProducto);

            return perdidaProductoDTO;
        }

        public PerdidaProductoDTO GetLoseProduct(Guid Id, bool trackChanges)
        {
            var perdidaProducto = _repository.PerdidaProducto.GetProductLose(Id, trackChanges);
            if(perdidaProducto == null)
            {
                throw new PerdidaProductoNotFoundException(Id);
            }

            var perdidaProductoDTO = _mapper.Map<PerdidaProductoDTO>(perdidaProducto);
            return perdidaProductoDTO;
        }

        public IEnumerable<PerdidaProductoDTO> GetLoseProductsByLose(Guid perdidaId, bool trackChanges)
        {
            var perdida = _repository.Perdida.GetLose(perdidaId, trackChanges);

            if (perdida is null)
            {
                throw new PerdidaNotFoundException(perdidaId);
            }
            var perdidaProductosFromDb = _repository.PerdidaProducto.GetLoseProductsByLose(perdidaId, trackChanges);
            var perdidaProductosDTO = _mapper.Map<IEnumerable<PerdidaProductoDTO>>(perdidaProductosFromDb);

            return perdidaProductosDTO;
        }

        public PerdidaProductoDTO GetLoseProductByLose(Guid perdidaId, Guid Id, bool trackChanges)
        {
            var perdida = _repository.Perdida.GetLose(perdidaId, trackChanges);
            if (perdida is null)
            {
                throw new PerdidaNotFoundException(perdidaId);
            }
            var perdProdloyeDb = _repository.PerdidaProducto.GetLoseProductByLose(perdidaId, Id, trackChanges);
            if (perdProdloyeDb is null)
            {
                throw new ProductoNotFoundException(Id);
            }
            var perdidaProducto = _mapper.Map<PerdidaProductoDTO>(perdProdloyeDb);
            return perdidaProducto;
        }

        public PerdidaProductoDTO CreateLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, PerdidaProductoForCreationDTO perdidaProductoForCreation, bool trackChanges)
        {
            var perdida = _repository.Perdida.GetLose(perdidaId, trackChanges);
            if (perdida is null)
                throw new PerdidaNotFoundException(perdidaId);


            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var perdidaProductoEntity = _mapper.Map<PerdidaProducto>(perdidaProductoForCreation);

            _repository.PerdidaProducto.CreateLoseProductForLoseProduct(perdidaId, productoId, perdidaProductoEntity);
            _repository.Save();

            var perdidaProductoToReturn = _mapper.Map<PerdidaProductoDTO>(perdidaProductoEntity);
            return perdidaProductoToReturn;
        }

        public void DeleteLoseProductForLose(Guid perdidaId, Guid productoId, Guid Id, bool trackChanges)
        {
            var perdida = _repository.Perdida.GetLose(perdidaId, trackChanges);
            if (perdida is null)
                throw new PerdidaNotFoundException(perdidaId);

            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var perdidaProductoForLose = _repository.PerdidaProducto.GetLoseProductByLose(perdidaId, Id,
            trackChanges);
            if (perdidaProductoForLose is null)
                throw new PerdidaProductoNotFoundException(Id);
            _repository.PerdidaProducto.DeleteLoseProduct(perdidaProductoForLose);
            _repository.Save();
        }

        public void UpdateLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, Guid id, PerdidaProductoForUpdateDTO perdidaProductoForUpdate, bool perdTrackChanges, bool prodTrackChanges, bool perdProdTrackChanges)
        {
            var perdida = _repository.Perdida.GetLose(perdidaId, perdTrackChanges);
            if (perdida is null)
            {
                throw new PerdidaNotFoundException(perdidaId);
            }

            var producto = _repository.Producto.GetProduct(productoId, prodTrackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }

            var perdidaProductoEntity = _repository.PerdidaProducto.GetLoseProductByLose(perdidaId, id, perdProdTrackChanges);
            if (perdidaProductoEntity is null)
            {
                throw new PerdidaProductoNotFoundException(id);
            }

            _mapper.Map(perdidaProductoForUpdate, perdidaProductoEntity);
            _repository.Save();
        }

        /**/

        public IEnumerable<PerdidaProductoDTO> GetLoseProductsByProduct(Guid productoId, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);

            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }
            var perdidaProductoFromDb = _repository.PerdidaProducto.GetLoseProductsByProduct(productoId, trackChanges);
            var perdidaProductoDTO = _mapper.Map<IEnumerable<PerdidaProductoDTO>>(perdidaProductoFromDb);

            return perdidaProductoDTO;
        }

        public PerdidaProductoDTO GetLoseProductByProduct(Guid productoId, Guid Id, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }
            var employeDb = _repository.PerdidaProducto.GetLoseProductByProduct(productoId, Id, trackChanges);
            if (employeDb is null)
            {
                throw new PerdidaProductoNotFoundException(Id);
            }
            var employee = _mapper.Map<PerdidaProductoDTO>(employeDb);
            return employee;
        }
    }
}
