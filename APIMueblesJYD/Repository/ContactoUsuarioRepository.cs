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
    public class ContactoUsuarioRepository : RepositoryBase<ContactoUsuarioDTO>, IContactoUsuarioRepository
    {
        public ContactoUsuarioRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public IEnumerable<ContactoUsuarioDTO> GetAllUserContacts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToList();

        public ContactoUsuarioDTO GetUserContact(int Id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(Id), trackChanges)
            .SingleOrDefault();
    }
}
