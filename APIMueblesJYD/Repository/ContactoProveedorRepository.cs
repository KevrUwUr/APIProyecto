using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class ContactoProveedorRepository : RepositoryBase<ContactoProveedor>, IContactoProveedorRepository
    {
        public ContactoProveedorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<ContactoProveedor> GetAllSupplierContact(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NombreProv)
                .ToList();

        public ContactoProveedor GetSupplierContact(Guid IdContactoProveedor, bool trackChanges) =>
            FindByCondition(c => c.IdContactoProveedor.Equals(IdContactoProveedor), trackChanges)
            .SingleOrDefault();
    }
}
