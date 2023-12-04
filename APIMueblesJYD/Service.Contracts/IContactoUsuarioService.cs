using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IContactoUsuarioService
    {
        IEnumerable<ContactoUsuarioDTO> GetAllUserContacts(bool trackChanges);
        ContactoUsuarioDTO GetUserContact(Guid Id, bool trackChanges);
        IEnumerable<ContactoUsuarioDTO> GetAllContactUsersForUser(Guid usuarioId, bool trackChanges);
        ContactoUsuarioDTO GetContactUserForUser(Guid usuarioId, Guid Id, bool trackChanges);
        ContactoUsuarioDTO CreateContactUserForUser(Guid usuarioId, ContactoUsuarioForCreationDTO contactoUsuarioForCreation, bool trackChanges);
        void DeleteContactUserForUser(Guid usuarioId, Guid Id, bool trackChanges);
        void UpdateContactUserForUser(Guid usuarioId, Guid id,
            ContactoUsuarioForUpdateDTO contactoUsuarioForUpdate, bool usuarioTrackChanges, bool contUsuarioTrackChanges);
        (ContactoUsuarioForUpdateDTO contUsuarioToPatch, ContactoUsuario contUsuarioEntity) GetContactoUsuarioForPatch
            (Guid usuarioId, Guid id, bool usuarioTrackChanges, bool contUsuarioTrackChanges);
        void SaveChangesForPatch(ContactoUsuarioForUpdateDTO contUsuarioToPatch, ContactoUsuario contUsuarioEntity);
    }
}
