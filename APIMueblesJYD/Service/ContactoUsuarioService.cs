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
    internal sealed class ContactoUsuarioService : IContactoUsuarioService
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

        public IEnumerable<ContactoUsuarioDTO> GetAllContactUsersForUser(Guid usuarioId, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, trackChanges);

            if (usuario is null)
            {
                throw new UsuarioNotFoundException(usuarioId);
            }
            var contUsuariosFromDb = _repository.ContactoUsuario.GetAllContactUsersForUser(usuarioId, trackChanges);
            var contUsuariosDTO = _mapper.Map<IEnumerable<ContactoUsuarioDTO>>(contUsuariosFromDb);

            return contUsuariosDTO;
        }

        public ContactoUsuarioDTO GetContactUserForUser(Guid usuarioId, Guid Id, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, trackChanges);
            if (usuario is null)
            {
                throw new UsuarioNotFoundException(usuarioId);
            }
            var contUsuarioDb = _repository.ContactoUsuario.GetContactUserForUser(usuarioId, Id, trackChanges);
            if (contUsuarioDb is null)
            {
                throw new ContactoUsuarioNotFoundException(Id);
            }
            var contUsuario = _mapper.Map<ContactoUsuarioDTO>(contUsuarioDb);
            return contUsuario;
        }

        public ContactoUsuarioDTO CreateContactUserForUser(Guid usuarioId, ContactoUsuarioForCreationDTO contUsuarioForCreation, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, trackChanges);
            if (usuario is null)
                throw new UsuarioNotFoundException(usuarioId);

            var contUsuarioEntity = _mapper.Map<ContactoUsuario>(contUsuarioForCreation);

            _repository.ContactoUsuario.CreateContactUserForUser(usuarioId, contUsuarioEntity);
            _repository.Save();

            var contUsuarioToReturn = _mapper.Map<ContactoUsuarioDTO>(contUsuarioEntity);
            return contUsuarioToReturn;
        }

        public void DeleteContactUserForUser(Guid usuarioId, Guid Id, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, trackChanges);
            if (usuario is null)
                throw new UsuarioNotFoundException(usuarioId);

            var contUsuarioForUsuario = _repository.ContactoUsuario.GetContactUserForUser(usuarioId, Id,
            trackChanges);
            if (contUsuarioForUsuario is null)
                throw new ContactoUsuarioNotFoundException(Id);

            _repository.ContactoUsuario.DeleteContactUser(contUsuarioForUsuario);
            _repository.Save();
        }

        public void UpdateContactUserForUser(Guid usuarioId, Guid id, ContactoUsuarioForUpdateDTO contUsuarioForUpdate, bool provTrackChanges, bool contUsuarioTrackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, provTrackChanges);
            if (usuario is null)
            {
                throw new UsuarioNotFoundException(usuarioId);
            }

            var contUsuarioEntity = _repository.ContactoUsuario.GetContactUserForUser(usuarioId, id, contUsuarioTrackChanges);
            if (contUsuarioEntity is null)
            {
                throw new ContactoUsuarioNotFoundException(id);
            }

            _mapper.Map(contUsuarioForUpdate, contUsuarioEntity);
            _repository.Save();
        }

        public (ContactoUsuarioForUpdateDTO contUsuarioToPatch, ContactoUsuario contUsuarioEntity) GetContactoUsuarioForPatch(Guid usuarioId, Guid id, bool provTrackChanges, bool contUsuarioTrackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, contUsuarioTrackChanges);
            if (usuario is null)
                throw new UsuarioNotFoundException(usuarioId);

            var contUsuarioEntity = _repository.ContactoUsuario.GetContactUserForUser(usuarioId, id, contUsuarioTrackChanges);

            if (contUsuarioEntity is null)
                throw new ContactoUsuarioNotFoundException(usuarioId);

            var contUsuarioToPatch = _mapper.Map<ContactoUsuarioForUpdateDTO>(contUsuarioEntity);
            return (contUsuarioToPatch, contUsuarioEntity);
        }

        public void SaveChangesForPatch(ContactoUsuarioForUpdateDTO contUsuarioToPatch, ContactoUsuario contUsuarioEntity)
        {
            _mapper.Map(contUsuarioToPatch, contUsuarioEntity);
            _repository.Save();
        }
    }
}
