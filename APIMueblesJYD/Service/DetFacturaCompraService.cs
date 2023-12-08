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
    internal sealed class DetFacturaCompraService : IDetFacturaCompraService
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

        public IEnumerable<DFacturaCompraDTO> GetAllDetBuyBillsByBuyBill(Guid facturaCompraId, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);

            if (facturaCompra is null)
            {
                throw new FacturaCompraNotFoundException(facturaCompraId);
            }
            var detalleFacturaComprasFromDb = _repository.DetFacturaCompra.GetAllDetBuyBillsByBuyBill(facturaCompraId, trackChanges);
            var detalleFacturaComprasDTO = _mapper.Map<IEnumerable<DFacturaCompraDTO>>(detalleFacturaComprasFromDb);

            return detalleFacturaComprasDTO;
        }

        public IEnumerable<DFacturaCompraDTO> GetAllDetBuyBillsByProduct(Guid productoId, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);

            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }
            var detalleFacturaCompraFromDb = _repository.DetFacturaCompra.GetAllDetBuyBillsByProduct(productoId, trackChanges);
            var detalleFacturaCompraDTO = _mapper.Map<IEnumerable<DFacturaCompraDTO>>(detalleFacturaCompraFromDb);

            return detalleFacturaCompraDTO;
        }

        public IEnumerable<DFacturaCompraDTO> GetAllDetBuyBillsForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);

            if (facturaCompra is null)
            {
                throw new FacturaCompraNotFoundException(facturaCompraId);
            }
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);

            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }

            var detalleFacturaComprasFromDb = _repository.DetFacturaCompra.GetDetBuyBillByBuyBillAndProduct(facturaCompraId, productoId, trackChanges);
            var detalleFacturaComprasDTO = _mapper.Map<IEnumerable<DFacturaCompraDTO>>(detalleFacturaComprasFromDb);

            return detalleFacturaComprasDTO;
        }
        public DFacturaCompraDTO GetDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);
            if (facturaCompra is null)
            {
                throw new FacturaCompraNotFoundException(facturaCompraId);
            }
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }

            var perdProdloyeDb = _repository.DetFacturaCompra.GetDetBuyBillByBuyBillAndProduct(facturaCompraId, productoId, trackChanges);
            if (perdProdloyeDb is null)
            {
                throw new DFacturaCompraNotFoundException(facturaCompraId, productoId);
            }
            var detalleFacturaCompra = _mapper.Map<DFacturaCompraDTO>(perdProdloyeDb);
            return detalleFacturaCompra;
        }

        public DFacturaCompraDTO CreateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DFacturaCompraForCreationDTO detalleFacturaCompraForCreation, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);
            if (facturaCompra is null)
                throw new FacturaCompraNotFoundException(facturaCompraId);


            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var detalleFacturaCompraEntity = _mapper.Map<DFacturaCompra>(detalleFacturaCompraForCreation);

            _repository.DFacturaCompra.CreateDetBuyBillForBuyBillAndProduct(facturaCompraId, productoId, detalleFacturaCompraEntity);
            _repository.Save();

            var detalleFacturaCompraToReturn = _mapper.Map<DFacturaCompraDTO>(detalleFacturaCompraEntity);
            return detalleFacturaCompraToReturn;
        }

        public void DeleteDetBuyBillForBuyBill(Guid facturaCompraId, Guid productoId, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);
            if (facturaCompra is null)
                throw new FacturaCompraNotFoundException(facturaCompraId);

            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var detalleFacturaCompraForBuyBill = _repository.DFacturaCompra.GetDetBuyBillByBuyBillAndProduct(facturaCompraId, productoId, trackChanges);
            if (detalleFacturaCompraForBuyBill is null)
                throw new DFacturaCompraNotFoundException(facturaCompraId, productoId);
            _repository.DFacturaCompra.DeleteDetBuyBill(detalleFacturaCompraForBuyBill);
            _repository.Save();
        }

        public void UpdateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DFacturaCompraForUpdateDTO detalleFacturaCompraForUpdate, bool perdTrackChanges, bool prodTrackChanges, bool perdProdTrackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, perdTrackChanges);
            if (facturaCompra is null)
            {
                throw new FacturaCompraNotFoundException(facturaCompraId);
            }

            var producto = _repository.Producto.GetProduct(productoId, prodTrackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }

            var detalleFacturaCompraEntity = _repository.DFacturaCompra.GetDetBuyBillByBuyBillAndProduct(facturaCompraId, productoId, perdProdTrackChanges);
            if (detalleFacturaCompraEntity is null)
            {
                throw new DFacturaCompraNotFoundException(facturaCompraId, productoId);
            }

            _mapper.Map(detalleFacturaCompraForUpdate, detalleFacturaCompraEntity);
            _repository.Save();
        }
    }
}
