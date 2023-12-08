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
            var facturaCompra = _repository.FacturaCompra.GetAllBuyBills(trackChanges);
            var facturaCompraDTO = _mapper.Map<IEnumerable<FacturaCompraDTO>>(facturaCompra);

            return facturaCompraDTO;
        }

        public FacturaCompraDTO GetBuyBill(Guid Id, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(Id, trackChanges);
            if(facturaCompra == null)
            {
                throw new FacturaCompraNotFoundException(Id);
            }

            var facturaCompraDTO = _mapper.Map<FacturaCompraDTO>(facturaCompra);
            return facturaCompraDTO;
        }

        public IEnumerable<FacturaCompraDTO> GetAllBuyBillsForSupplier(Guid proveedorId, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);

            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }
            var facComprasFromDb = _repository.FacturaCompra.GetAllBuyBillsForSupplier(proveedorId, trackChanges);
            var facComprasDTO = _mapper.Map<IEnumerable<FacturaCompraDTO>>(facComprasFromDb);

            return facComprasDTO;
        }

        public FacturaCompraDTO GetBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }
            var facCompraDb = _repository.FacturaCompra.GetBuyBillForSupplier(proveedorId, Id, trackChanges);
            if (facCompraDb is null)
            {
                throw new FacturaCompraNotFoundException(Id);
            }
            var facCompra = _mapper.Map<FacturaCompraDTO>(facCompraDb);
            return facCompra;
        }

        public FacturaCompraDTO CreateBuyBillForSupplier(Guid proveedorId, FacturaCompraForCreationDTO facCompraForCreation, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);

            var facCompraEntity = _mapper.Map<FacturaCompra>(facCompraForCreation);

            _repository.FacturaCompra.CreateBuyBillForSupplier(proveedorId, facCompraEntity);
            _repository.Save();

            var facCompraToReturn = _mapper.Map<FacturaCompraDTO>(facCompraEntity);
            return facCompraToReturn;
        }

        public void DeleteBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);

            var facCompraForProveedor = _repository.FacturaCompra.GetBuyBillForSupplier(proveedorId, Id,
            trackChanges);
            if (facCompraForProveedor is null)
                throw new FacturaCompraNotFoundException(Id);

            _repository.FacturaCompra.DeleteBuyBill(facCompraForProveedor);
            _repository.Save();
        }

        public void UpdateBuyBillForSupplier(Guid proveedorId, Guid id, FacturaCompraForUpdateDTO facCompraForUpdate, bool proveedorTrackChanges, bool facCompraTrackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, proveedorTrackChanges);
            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }

            var facCompraEntity = _repository.FacturaCompra.GetBuyBillForSupplier(proveedorId, id, facCompraTrackChanges);
            if (facCompraEntity is null)
            {
                throw new FacturaCompraNotFoundException(id);
            }

            _mapper.Map(facCompraForUpdate, facCompraEntity);
            _repository.Save();
        }

        public (FacturaCompraForUpdateDTO facCompraToPatch, FacturaCompra facCompraEntity) GetFacturaCompraForPatch(Guid proveedorId, Guid id, bool proveedorTrackChanges, bool facCompraTrackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, facCompraTrackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);

            var facCompraEntity = _repository.FacturaCompra.GetBuyBillForSupplier(proveedorId, id, facCompraTrackChanges);

            if (facCompraEntity is null)
                throw new FacturaCompraNotFoundException(proveedorId);

            var facCompraToPatch = _mapper.Map<FacturaCompraForUpdateDTO>(facCompraEntity);
            return (facCompraToPatch, facCompraEntity);
        }

        public void SaveChangesForPatch(FacturaCompraForUpdateDTO facCompraToPatch, FacturaCompra facCompraEntity)
        {
            _mapper.Map(facCompraToPatch, facCompraEntity);
            _repository.Save();
        }
    }
}
