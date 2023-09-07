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
    internal sealed class ProveedorService : IProveedorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProveedorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProveedorDTO> GetAllSuppliers(bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetAllSuppliers(trackChanges);
            var proveedorDTO = _mapper.Map<IEnumerable<ProveedorDTO>>(proveedor);

            return proveedorDTO;
        }

        public ProveedorDTO GetSupplier(Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(Id, trackChanges);
            if (proveedor == null)
            {
                throw new ProveedorNotFoundException(Id);
            }

            var proveedorDTO = _mapper.Map<ProveedorDTO>(proveedor);
            return proveedorDTO;
        }
        public ProveedorDTO CreateSupplier(ProveedorForCreationDTO supplier)
        {
            var proveedorEntity = _mapper.Map<Proveedor>(supplier);

            _repository.Proveedor.CreateSupplier(proveedorEntity);
            _repository.Save();

            var supplierToReturn = _mapper.Map<ProveedorDTO>(proveedorEntity);
            return supplierToReturn;
        }
        public IEnumerable<ProveedorDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var supplierEntities = _repository.Proveedor.GetByIds(ids, trackChanges);
            if (ids.Count() != supplierEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var companiesToReturn = _mapper.Map<IEnumerable<ProveedorDTO>>(supplierEntities);

            return companiesToReturn;
        }
        public (IEnumerable<ProveedorDTO> proveedores, string ids) CreateSupplierCollection
            (IEnumerable<ProveedorForCreationDTO> supplierCollection)
        {
            if (supplierCollection is null)
                throw new ProveedorCollectionBadRequest();
            var supplierEntities = _mapper.Map<IEnumerable<Proveedor>>(supplierCollection);
            foreach (var supplier in supplierEntities)
            {
                _repository.Proveedor.CreateSupplier(supplier);
            }
            _repository.Save();
            var supplierCollectionToReturn =
            _mapper.Map<IEnumerable<ProveedorDTO>>(supplierEntities);
            var ids = string.Join(",", supplierCollectionToReturn.Select(c => c.IdProveedor));
            return (suppliers: supplierCollectionToReturn, ids: ids);
        }
        public void DeleteSupplier(Guid supplierId, bool trackChanges)
        {
            var supplier = _repository.Proveedor.GetSupplier(supplierId, trackChanges);
            if (supplier == null)
                throw new ProveedorNotFoundException(supplierId);

            _repository.Proveedor.DeleteSupplier(supplier);
            _repository.Save();
        }
        public void UpdateSupplier(Guid supplierId, ProveedorForUpdateDTO supplierForUpdate, bool trackChanges)
        {
            var supplierEntity = _repository.Proveedor.GetSupplier(supplierId, trackChanges);
            if (supplierEntity == null)
                throw new ProveedorNotFoundException(supplierId);

            _mapper.Map(supplierForUpdate, supplierEntity);
            _repository.Save();
        }
    }
}
