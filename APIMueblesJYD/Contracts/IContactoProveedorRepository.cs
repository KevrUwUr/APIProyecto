using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IContactoProveedorRepository
    {
        IEnumerable<ContactoProveedor> GetAllSupplierContacts(bool trackChanges);
        ContactoProveedor GetSuplierContact(Guid suplierContactId, bool trackChanges);
    }
}
