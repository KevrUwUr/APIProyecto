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
        CargoDto GetCargo(int cargoId, bool trackChanges);
    }
}
