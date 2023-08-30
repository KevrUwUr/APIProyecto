using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICargoRepository> _cargoRepository;
        
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _cargoRepository = new Lazy<ICargoRepository>(() => 
            new CargoRepository(repositoryContext));
        }
        public ICargoRepository Cargo=>_cargoRepository.Value

        public void Save() => _repositoryContext.SaveChanges();
    }
}
