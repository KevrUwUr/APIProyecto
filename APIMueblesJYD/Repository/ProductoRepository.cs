using Contracts;
using Entities.Models;
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

        public Producto GetProducts(Guid IdProducto, bool trackChanges) =>
            FindByCondition(c => c.IdProducto.Equals(IdProducto), trackChanges)
            .SingleOrDefault();

    }
}
