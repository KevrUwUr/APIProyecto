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
            :base(repositoryContext)
        {
        }

        public IEnumerable<Cargo> GetAllCargos(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NombreCargo)
                .ToList();
    }
}
