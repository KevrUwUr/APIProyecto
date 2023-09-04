using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PerdidaRepository : RepositoryBase<PerdidaDTO>, IPerdidaRepository
    {
        public PerdidaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<PerdidaDTO> GetAllLoses(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdPerdida)
                .ToList();

        public PerdidaDTO GetLose(int IdPerdida, bool trackChanges) =>
            FindByCondition(c => c.IdPerdida.Equals(IdPerdida), trackChanges)
            .SingleOrDefault();

    }
}
