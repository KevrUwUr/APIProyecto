using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductoService
    {
        IEnumerable<ProductoDTO> GetAllProducts(bool trackChanges);
        ProductoDTO GetProduct(Guid Id, bool trackChanges);
        IEnumerable<ProductoDTO> GetProductsCategory(Guid categoriaId, bool trackChanges);
        ProductoDTO GetProductCategory(Guid categoriaId, Guid Id, bool trackChanges);
        ProductoDTO CreateProductForCategory(Guid categoriaId, ProductoForCreationDTO productoForCreation, bool trackChanges);
        void DeleteProductForCategory(Guid categoryId, Guid Id, bool trackChanges);
        void UpdateProductForCategory(Guid categoriaId, Guid id,
            ProductoForUpdateDTO productoForUpdate, bool catTrackChanges, bool prodTrackChanges);
        //ProductoDTO CreateProduct(ProductoForCreationDTO product);
        //IEnumerable<ProductoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        //(IEnumerable<ProductoDTO> productos, string ids) CreateProductCollection
        //    (IEnumerable<ProductoForCreationDTO> productCollection);
        //void DeleteProduct(Guid productId, bool trackChanges);
        //void UpdateProduct(Guid productId, ProductoForUpdateDTO productForUpdate, bool trackChanges);
    }
}
