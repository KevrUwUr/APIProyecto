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
    public class PerdidaProductoRepository : RepositoryBase<PerdidaProducto>, IPerdidaProductoRepository
    {
        public PerdidaProductoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<PerdidaProducto> GetAllProductLoses(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdPerdida)
                .ToList();

        public PerdidaProducto GetProductLose(Guid IdPerdidaProducto, bool trackChanges) =>
            FindByCondition(c => c.IdPerdida.Equals(IdPerdidaProducto), trackChanges)
            .SingleOrDefault();

    }
}
