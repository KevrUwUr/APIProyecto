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
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Usuario> GetAllUsers(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NumDocumento)
                .ToList();

        public Usuario GetUser(Guid IdUsuario, bool trackChanges) =>
            FindByCondition(c => c.IdUsuario.Equals(IdUsuario), trackChanges)
            .SingleOrDefault();

        public void CreateUser(Usuario user) => Create(user);
        public IEnumerable<Usuario> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.IdUsuario), trackChanges)
            .ToList();
        public void DeleteUser(Usuario user) => Delete(user);
    }
}
