using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICargoRepository
    {
        IEnumerable<Cargo> GetAllCargos(bool trackChanges);
        Cargo GetCargo(Guid cargoId, bool trackChanges);
        void CreateCargo(Cargo cargo);
        IEnumerable<Cargo> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCargo(Cargo cargo);
    }
}