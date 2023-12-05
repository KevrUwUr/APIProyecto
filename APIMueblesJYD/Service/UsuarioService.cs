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
    internal sealed class UsuarioService : IUsuarioService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UsuarioService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<UsuarioDTO> GetAllUsers(bool trackChanges)
        {
            var usuario = _repository.Usuario.GetAllUsers(trackChanges);
            var usuarioDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuario);

            return usuarioDTO;
        }

        public UsuarioDTO GetUser(Guid Id, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(Id, trackChanges);
            if(usuario == null)
            {
                throw new UsuarioNotFoundException(Id);
            }

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDTO;
        }
        public UsuarioDTO CreateUser(UsuarioForCreationDTO user)
        {
            var proveedorEntity = _mapper.Map<Usuario>(user);

            _repository.Usuario.CreateUser(proveedorEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<UsuarioDTO>(proveedorEntity);
            return userToReturn;
        }
        public IEnumerable<UsuarioDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var userEntities = _repository.Usuario.GetByIds(ids, trackChanges);
            if (ids.Count() != userEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var usersToReturn = _mapper.Map<IEnumerable<UsuarioDTO>>(userEntities);

            return usersToReturn;
        }
        public (IEnumerable<UsuarioDTO> usuarios, string ids) CreateUserCollection
            (IEnumerable<UsuarioForCreationDTO> userCollection)
        {
            if (userCollection is null)
                throw new UsuarioCollectionBadRequest();
            var userEntities = _mapper.Map<IEnumerable<Usuario>>(userCollection);
            foreach (var user in userEntities)
            {
                _repository.Usuario.CreateUser(user);
            }
            _repository.Save();
            var userCollectionToReturn =
            _mapper.Map<IEnumerable<UsuarioDTO>>(userEntities);
            var ids = string.Join(",", userCollectionToReturn.Select(c => c.IdUsuario));
            return (users: userCollectionToReturn, ids: ids);
        }
        public void DeleteUser(Guid userId, bool trackChanges)
        {
            var user = _repository.Usuario.GetUser(userId, trackChanges);
            if (user == null)
                throw new UsuarioNotFoundException(userId);

            _repository.Usuario.DeleteUser(user);
            _repository.Save();
        }
        public void UpdateUser(Guid userId, UsuarioForUpdateDTO userForUpdate, bool trackChanges)
        {
            var userEntity = _repository.Usuario.GetUser(userId, trackChanges);
            if (userEntity == null)
                throw new UsuarioNotFoundException(userId);

            _mapper.Map(userForUpdate, userEntity);
            _repository.Save();
        }
    }
}
