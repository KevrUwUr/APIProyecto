using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactoProveedorRepository : RepositoryBase<ContactoProveedor>, IContactoProveedorRepository
    {
        public ContactoProveedorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public IEnumerable<ContactoProveedor> GetAllSupplierContacts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Proveedor)
            .ToList();

        public ContactoProveedor GetSupplierContact(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.IdContactoProveedor.Equals(Id), trackChanges)
            .SingleOrDefault();
    }
}
