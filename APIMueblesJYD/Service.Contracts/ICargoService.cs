using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICargoService
    {
        IEnumerable<CargoDTO> GetAllCargos(bool trackChanges);
        CargoDTO GetCargo(Guid cargoId, bool trackChanges);

        CargoDTO CreateCargo(CargoForCreationDTO cargo);

        IEnumerable<CargoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        (IEnumerable<CargoDTO> cargos, string ids) CreateCargoCollection
                (IEnumerable<CargoForCreationDTO> cargoCollection);

        void DeleteCargo(Guid cargoId, bool trackChanges);

        void UpdateCargo(Guid cargoId, CargoForUpdateDTO cargoForUpdate, bool trackChanges);
    }
}
