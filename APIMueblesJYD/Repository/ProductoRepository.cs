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
    public class ProductoRepository : RepositoryBase<Producto>, IProductoRepository
    {
        public ProductoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Producto> GetAllProducts(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Nombre)
                .ToList();

        public Producto GetProduct(Guid ProductoId, bool trackChanges) =>
            FindByCondition(c => c.ProductoId.Equals(ProductoId), trackChanges)
            .SingleOrDefault();

    }
}
