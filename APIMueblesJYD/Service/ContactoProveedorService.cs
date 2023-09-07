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

        public IEnumerable<ContactoProveedorDTO> GetAllSuplierContacts(bool trackChanges)
        {
            var contactoProveedor = _repository.ContactoProveedor.GetAllSupplierContacts(trackChanges);
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
    }
}
