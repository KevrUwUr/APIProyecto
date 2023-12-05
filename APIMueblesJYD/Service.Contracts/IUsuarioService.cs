using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDTO> GetAllUsers(bool trackChanges);
        UsuarioDTO GetUser(Guid Id, bool trackChanges);
        UsuarioDTO CreateUser(UsuarioForCreationDTO user);
        IEnumerable<UsuarioDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<UsuarioDTO> usuarios, string ids) CreateUserCollection
            (IEnumerable<UsuarioForCreationDTO> userCollection);
        void DeleteUser(Guid userId, bool trackChanges);
        void UpdateUser(Guid userId, UsuarioForUpdateDTO userForUpdate, bool trackChanges);
    }
}
