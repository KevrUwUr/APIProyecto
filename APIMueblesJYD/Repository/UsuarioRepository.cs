using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsuarioRepository : RepositoryBase<UsuarioDTO>, IUsuarioRepository
    {
        public UsuarioRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<UsuarioDTO> GetAllUsers(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NumDocumento)
                .ToList();

        public UsuarioDTO GetUser(Guid IdUsuario, bool trackChanges) =>
            FindByCondition(c => c.IdUsuario.Equals(IdUsuario), trackChanges)
            .SingleOrDefault();

    }
}
