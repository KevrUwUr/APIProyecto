using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAllProducts(bool trackChanges);
        Producto GetProduct(Guid ProductoId, bool trackChanges);
        IEnumerable<Producto> GetProductsCategory(Guid categoriaId, bool trackChanges);
        Producto GetProductCategory(Guid categoriaId, Guid Id, bool trackChanges);
        void CreateProductForCategory(Guid categoriaId, Producto producto);
        void DeleteProduct(Producto producto);
        //void CreateProduct(Producto producto);
        //IEnumerable<Producto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        //void DeleteProduct(Producto producto);
    }
}
