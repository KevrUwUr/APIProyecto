using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IContactoProveedorService
    {
        IEnumerable<ContactoProveedorDTO> GetAllSuplierContacts(bool trackChanges);
        ContactoProveedorDTO GetSuplierContact(int Id, bool trackChanges);
    }
}
