using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PerdidaProductoRepository : RepositoryBase<Perdida_Producto>, IPerdidaProductoRepository
    {
        public PerdidaProductoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Perdida_Producto> GetAllProductLose(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.PerdidaProductoId)
                .ToList();

        public Perdida_Producto GetLoses(Guid IdPerdidaProducto, bool trackChanges) =>
            FindByCondition(c => c.PerdidaProductoId.Equals(IdPerdidaProducto), trackChanges)
            .SingleOrDefault();

    }
}
