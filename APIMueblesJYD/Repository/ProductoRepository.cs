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

        public IEnumerable<Producto> GetProductsCategory(Guid categoriaId, bool trackChanges) =>
            FindByCondition(e => e.IdCategoria.Equals(categoriaId), trackChanges)
            .OrderBy(e => e.Nombre)
            .ToList();
        public Producto GetProductCategory(Guid categoriaId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.IdCategoria.Equals(categoriaId) && e.ProductoId == (Id), trackChanges)
            .SingleOrDefault();

        public void CreateProductForCategory(Guid categoriaId, Producto producto)
        {
            producto.IdCategoria = categoriaId;
            Create(producto);
        }

        public void DeleteProduct(Producto producto) => Delete(producto);
        //public void CreateProduct(Producto producto) => Create(producto);
        //public IEnumerable<Producto> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        //    FindByCondition(x => ids.Contains(x.ProductoId), trackChanges)
        //    .ToList();
        //public void DeleteProduct(Producto producto) => Delete(producto);
    }
}
