﻿using Entities.Models;
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
        ContactoProveedor GetSupplierContact(Guid suplierContactId, bool trackChanges);
        IEnumerable<ContactoProveedor> GetAllContactSuppliersForSupplier(Guid proveedorId, bool trackChanges);
        ContactoProveedor GetContactSupplierForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        void CreateContactSupplierForSupplier(Guid proveedorId, ContactoProveedor contProv);
        void DeleteContactSupplier(ContactoProveedor contProv);
    }
}
