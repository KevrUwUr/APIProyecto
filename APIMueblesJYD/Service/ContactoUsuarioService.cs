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
    internal sealed class ContactoUsuarioService : IContactoUsuarioRepository
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ContactoUsuarioService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ContactoUsuarioDTO> GetAllUserContacts(bool trackChanges)
        {
            var contactoUsuario = _repository.ContactoUsuario.GetAllUserContacts(trackChanges);
            var contactoUsuarioDTO = _mapper.Map<IEnumerable<ContactoUsuarioDTO>>(contactoUsuario);

            return contactoUsuarioDTO;
        }

        public ContactoUsuarioDTO GetUserContact(Guid userContactId, bool trackChanges)
        {
            var contactoUsuario = _repository.ContactoUsuario.GetUserContact(userContactId, trackChanges);
            if(contactoUsuario == null)
            {
                throw new ContactoUsuarioNotFoundException(userContactId);
            }

            var contactoUsuarioDTO = _mapper.Map<ContactoUsuarioDTO>(contactoUsuario);
            return contactoUsuarioDTO;
        }

    }
}
