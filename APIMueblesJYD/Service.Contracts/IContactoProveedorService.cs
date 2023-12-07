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
        IEnumerable<ContactoProveedorDTO> GetAllSupplierContacts(bool trackChanges);
        ContactoProveedorDTO GetSupplierContact(Guid Id, bool trackChanges);
        IEnumerable<ContactoProveedorDTO> GetAllContactSuppliersForSupplier(Guid proveedorId, bool trackChanges);
        ContactoProveedorDTO GetContactSupplierForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        ContactoProveedorDTO CreateContactSupplierForSupplier(Guid proveedorId, ContactoProveedorForCreationDTO contactoProvForCreation, bool trackChanges);
        void DeleteContactSupplierForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        void UpdateContactSupplierForSupplier(Guid proveedorId, Guid Id,
            ContactoProveedorForUpdateDTO contactoProvForUpdate, bool provTrackChanges, bool contProvTrackChanges);
        (ContactoProveedorForUpdateDTO contProvToPatch, ContactoProveedor contProvEntity) GetContactoProveedorForPatch
            (Guid proveedorId, Guid Id, bool provTrackChanges, bool contProvTrackChanges);
        void SaveChangesForPatch(ContactoProveedorForUpdateDTO contProvToPatch, ContactoProveedor contProvEntity);
    }
}
