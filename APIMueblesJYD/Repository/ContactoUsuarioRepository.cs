using Contracts;
using Entities.Models;
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
            : base(repositoryContext)
        {
        }

        public IEnumerable<ContactoUsuario> GetAllUserContacts(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NumeroTelefonico)
                .ToList();

        public ContactoUsuario GetUserContact(Guid IdContactoCliente, bool trackChanges) =>
            FindByCondition(c => c.IdContactoCliente.Equals(IdContactoCliente), trackChanges)
            .SingleOrDefault();

    }
}
