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
        public IEnumerable<ContactoProveedor> GetAllSuppliersContacts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Proveedor)
            .ToList();

        public ContactoProveedor GetSupplierContact(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.IdContactoProveedor.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<ContactoProveedor> GetAllContactSuppliersForSupplier(Guid proveedorId, bool trackChanges) =>
            FindByCondition(e => e.IdProveedor.Equals(proveedorId), trackChanges)
            .OrderBy(e => e.Proveedor)
            .ToList();

        public ContactoProveedor GetContactSupplierForSupplier(Guid proveedorId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.IdProveedor.Equals(proveedorId) && e.IdContactoProveedor == (Id), trackChanges)
            .SingleOrDefault();

        public void CreateContactSupplierForSupplier(Guid proveedorId, ContactoProveedor contProv)
        {
            contProv.IdProveedor = proveedorId;
            Create(contProv);
        }

        public void DeleteContactSupplier(ContactoProveedor contProv) => Delete(contProv);
    }
}
