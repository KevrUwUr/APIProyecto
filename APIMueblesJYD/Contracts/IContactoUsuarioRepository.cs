using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IContactoUsuarioRepository
    {
        IEnumerable<ContactoUsuario> GetAllUserContacts(bool trackChanges);
        ContactoUsuario GetUserContact(Guid Id, bool trackChanges);
        IEnumerable<ContactoUsuario> GetAllContactUsersForUser(Guid usuarioId, bool trackChanges);
        ContactoUsuario GetContactUserForUser(Guid usuarioId, Guid Id, bool trackChanges);
        void CreateContactUserForUser(Guid usuarioId, ContactoUsuario contUsuario);
        void DeleteContactUser(ContactoUsuario contUsuario);
    }
}
