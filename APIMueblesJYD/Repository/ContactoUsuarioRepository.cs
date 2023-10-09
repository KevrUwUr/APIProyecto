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
    public class ContactoUsuarioRepository : RepositoryBase<ContactoUsuario>, IContactoUsuarioRepository
    {
        public ContactoUsuarioRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public IEnumerable<ContactoUsuario> GetAllUserContacts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.IdContactoCliente)
            .ToList();

        public ContactoUsuario GetUserContact(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.IdContactoCliente.Equals(Id), trackChanges)
            .SingleOrDefault();
        public IEnumerable<ContactoUsuario> GetAllContactUsersForUser(Guid usuarioId, bool trackChanges) =>
            FindByCondition(e => e.IdUsuario.Equals(usuarioId), trackChanges)
            .OrderBy(e => e.Usuario)
            .ToList();
        public ContactoUsuario GetContactUserForUser(Guid usuarioId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.IdUsuario.Equals(usuarioId) && e.IdContactoCliente == (Id), trackChanges)
            .SingleOrDefault();

        public void CreateContactUserForUser(Guid usuarioId, ContactoUsuario contUsuario)
        {
            contUsuario.IdUsuario = usuarioId;
            Create(contUsuario);
        }

        public void DeleteContactUser(ContactoUsuario contUsuario) => Delete(contUsuario);
    }
}
