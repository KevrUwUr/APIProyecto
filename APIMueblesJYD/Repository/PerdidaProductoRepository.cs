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
    public class PerdidaProductoRepository : RepositoryBase<PerdidaProductoDTO>, IPerdidaProductoRepository
    {
        public PerdidaProductoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<PerdidaProductoDTO> GetAllProductLoses(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Id)
                .ToList();

        public PerdidaProductoDTO GetProductLose(int IdPerdidaProducto, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(IdPerdidaProducto), trackChanges)
            .SingleOrDefault();

    }
}
