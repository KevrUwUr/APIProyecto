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
    internal sealed class ContactoProveedorService : IContactoProveedorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ContactoProveedorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ContactoProveedorDTO> GetAllSupplierContacts(bool trackChanges)
        {
            var contactoProveedor = _repository.ContactoProveedor.GetAllSuppliersContacts(trackChanges);
            var contactoProveedorDTO = _mapper.Map<IEnumerable<ContactoProveedorDTO>>(contactoProveedor);

            return contactoProveedorDTO;
        }

        public ContactoProveedorDTO GetSupplierContact(Guid Id, bool trackChanges)
        {
            var contactoProveedor = _repository.ContactoProveedor.GetSupplierContact(Id, trackChanges);
            if(contactoProveedor == null)
            {
                throw new ContactoProveedorNotFoundException(Id);
            }

            var contactoProveedorDTO = _mapper.Map<ContactoProveedorDTO>(contactoProveedor);
            return contactoProveedorDTO;
        }

        public IEnumerable<ContactoProveedorDTO> GetAllContactSuppliersForSupplier(Guid proveedorId, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);

            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }
            var contProvsFromDb = _repository.ContactoProveedor.GetAllContactSuppliersForSupplier(proveedorId, trackChanges);
            var contProvsDTO = _mapper.Map<IEnumerable<ContactoProveedorDTO>>(contProvsFromDb);

            return contProvsDTO;
        }

        public ContactoProveedorDTO GetContactSupplierForSupplier(Guid proveedorId, Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }
            var contProvDb = _repository.ContactoProveedor.GetContactSupplierForSupplier(proveedorId, Id, trackChanges);
            if (contProvDb is null)
            {
                throw new ContactoProveedorNotFoundException(Id);
            }
            var contProv = _mapper.Map<ContactoProveedorDTO>(contProvDb);
            return contProv;
        }

        public ContactoProveedorDTO CreateContactSupplierForSupplier(Guid proveedorId, ContactoProveedorForCreationDTO contProvForCreation, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);

            var contProvEntity = _mapper.Map<ContactoProveedor>(contProvForCreation);

            _repository.ContactoProveedor.CreateContactSupplierForSupplier(proveedorId, contProvEntity);
            _repository.Save();

            var contProvToReturn = _mapper.Map<ContactoProveedorDTO>(contProvEntity);
            return contProvToReturn;
        }

        public void DeleteContactSupplierForSupplier(Guid proveedorId, Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);
            var contProvForProveedor = _repository.ContactoProveedor.GetContactSupplierForSupplier(proveedorId, Id,
            trackChanges);
            if (contProvForProveedor is null)
                throw new ContactoProveedorNotFoundException(Id);
            _repository.ContactoProveedor.DeleteContactSupplier(contProvForProveedor);
            _repository.Save();
        }

        public void UpdateContactSupplierForSupplier(Guid proveedorId, Guid Id, ContactoProveedorForUpdateDTO contProvForUpdate, bool empTrackChanges, bool contProvTrackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, empTrackChanges);
            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }

            var contProvEntity = _repository.ContactoProveedor.GetContactSupplierForSupplier(proveedorId, Id, contProvTrackChanges);
            if (contProvEntity is null)
            {
                throw new ContactoProveedorNotFoundException(Id);
            }

            _mapper.Map(contProvForUpdate, contProvEntity);
            _repository.Save();
        }

        public (ContactoProveedorForUpdateDTO contProvToPatch, ContactoProveedor contProvEntity) GetContactoProveedorForPatch(Guid proveedorId, Guid Id, bool empTrackChanges, bool contProvTrackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, contProvTrackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);

            var contProvEntity = _repository.ContactoProveedor.GetContactSupplierForSupplier(proveedorId, Id, contProvTrackChanges);

            if (contProvEntity is null)
                throw new ContactoProveedorNotFoundException(proveedorId);

            var contProvToPatch = _mapper.Map<ContactoProveedorForUpdateDTO>(contProvEntity);
            return (contProvToPatch, contProvEntity);
        }

        public void SaveChangesForPatch(ContactoProveedorForUpdateDTO contProvToPatch, ContactoProveedor contProvEntity)
        {
            _mapper.Map(contProvToPatch, contProvEntity);
            _repository.Save();
        }
    }
}
