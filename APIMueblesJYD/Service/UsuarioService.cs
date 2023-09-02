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
    internal sealed class UsuarioService : IUsuarioRepository
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
    }
}
