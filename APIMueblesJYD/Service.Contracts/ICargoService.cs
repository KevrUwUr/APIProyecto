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
        IEnumerable<CargoDto> GetAllCargos(bool trackChanges);
        CargoDto GetCargo(Guid cargoId, bool trackChanges);

        CargoDto CreateCargo(CargoForCreationDto cargo);

        IEnumerable<CargoDto> GetByIds(IEnumerable<Guid>ids, bool trackChanges );

        (IEnumerable<CargoDto> cargo, string ids) CreateCargoCollection
                (IEnumerable<EmpleadoCargoForCreationDTO> cargoCollection);

        void DeleteCargo(Guid cargoId, bool trackChanges);
        
        void UpdateCargo(Guid cargoId, CargoForUpdateDTO cargoForUpdate, bool trackChanges);
    }
}
