using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CargoRepository : RepositoryBase<Cargo>, ICargoRepository
    {
        public CargoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Cargo> GetAllCargos(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NombreCargo)
                .ToList();

        public Cargo GetCargo(Guid cargoId, bool trackChanges) =>
            FindByCondition(c => c.CargoId.Equals(cargoId), trackChanges)
            .SingleOrDefault();

        public void CreateCargo(Cargo cargo) => Create(cargo);

        public IEnumerable<Cargo> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.CargoId), trackChanges);


        public void DeleteCargo(Cargo cargo) => Delete(cargo);
    }
}