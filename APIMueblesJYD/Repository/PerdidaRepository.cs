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
    public class PerdidaRepository : RepositoryBase<Perdida>, IPerdidaRepository
    {
        public PerdidaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Perdida> GetAllLoses(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdPerdida)
                .ToList();

        public Perdida GetLose(Guid IdPerdida, bool trackChanges) =>
            FindByCondition(c => c.IdPerdida.Equals(IdPerdida), trackChanges)
            .SingleOrDefault();

        public void CreateLose(Perdida lose) => Create(lose);
        public IEnumerable<Perdida> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.IdPerdida), trackChanges)
            .ToList();
        public void DeleteLose(Perdida lose) => Delete(lose);
    }
}
