using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ProductoService : IProductoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProductoDTO> GetAllProducts(bool trackChanges)
        {
            var producto = _repository.Producto.GetAllProducts(trackChanges);
            var productoDTO = _mapper.Map<IEnumerable<ProductoDTO>>(producto);

            return productoDTO;
        }

        public ProductoDTO GetProduct(Guid Id, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(Id, trackChanges);
            if(producto == null)
            {
                throw new ProductoNotFoundException(Id);
            }

            var productoDTO = _mapper.Map<ProductoDTO>(producto);
            return productoDTO;
        }

        public IEnumerable<ProductoDTO> GetProductsCategory(Guid categoriaId, bool trackChanges)
        {
            var categoria = _repository.Categoria.GetCategory(categoriaId, trackChanges);

            if (categoria is null)
            {
                throw new CategoriaNotFoundException(categoriaId);
            }
            var productosFromDb = _repository.Producto.GetProductsCategory(categoriaId, trackChanges);
            var productosDTO = _mapper.Map<IEnumerable<ProductoDTO>>(productosFromDb);

            return productosDTO;
        }

        public ProductoDTO GetProductCategory(Guid categoriaId, Guid Id, bool trackChanges)
        {
            var categoria = _repository.Categoria.GetCategory(categoriaId, trackChanges);
            if (categoria is null)
            {
                throw new CategoriaNotFoundException(categoriaId);
            }
            var productoDb = _repository.Producto.GetProductCategory(categoriaId, Id, trackChanges);
            if (productoDb is null)
            {
                throw new ProductoNotFoundException(Id);
            }
            var producto = _mapper.Map<ProductoDTO>(productoDb);
            return producto;
        }

        public ProductoDTO CreateProductForCategory(Guid categoriaId, ProductoForCreationDTO productoForCreation, bool trackChanges)
        {
            var categoria = _repository.Categoria.GetCategory(categoriaId, trackChanges);
            if (categoria is null)
                throw new CategoriaNotFoundException(categoriaId);

            var productoEntity = _mapper.Map<Producto>(productoForCreation);

            _repository.Producto.CreateProductForCategory(categoriaId, productoEntity);
            _repository.Save();

            var productoToReturn = _mapper.Map<ProductoDTO>(productoEntity);
            return productoToReturn;
        }

        public void DeleteProductForCategory(Guid categoriaId, Guid Id, bool trackChanges)
        {
            var categoria = _repository.Categoria.GetCategory(categoriaId, trackChanges);
            if (categoria is null)
                throw new CategoriaNotFoundException(categoriaId);
            var productoForCategoria = _repository.Producto.GetProductCategory(categoriaId, Id,
            trackChanges);
            if (productoForCategoria is null)
                throw new ProductoNotFoundException(Id);
            _repository.Producto.DeleteProduct(productoForCategoria);
            _repository.Save();
        }

        public void UpdateProductForCategory(Guid categoriaId, Guid id, ProductoForUpdateDTO productoForUpdate, bool catTrackChanges, bool prodTrackChanges)
        {
            var categoria = _repository.Categoria.GetCategory(categoriaId, catTrackChanges);
            if (categoria is null)
            {
                throw new CategoriaNotFoundException(categoriaId);
            }

            var productoEntity = _repository.Producto.GetProductCategory(categoriaId, id, prodTrackChanges);
            if (productoEntity is null)
            {
                throw new ProductoNotFoundException(id);
            }

            _mapper.Map(productoForUpdate, productoEntity);
            _repository.Save();
        }

        public (ProductoForUpdateDTO productoToPatch, Producto productoEntity) GetProductoForPatch(Guid categoriaId, Guid id, bool catTrackChanges, bool prodTrackChanges)
        {
            var categoria = _repository.Categoria.GetCategory(categoriaId, catTrackChanges);
            if (categoria is null)
                throw new CategoriaNotFoundException(categoriaId);
            var productoEntity = _repository.Producto.GetProductCategory(categoriaId, id,
            prodTrackChanges);
            if (productoEntity is null)
                throw new ProductoNotFoundException(categoriaId);
            var productoToPatch = _mapper.Map<ProductoForUpdateDTO>(productoEntity);
            return (productoToPatch, productoEntity);
        }

        public void SaveChangesForPatch(ProductoForUpdateDTO productoToPatch, Producto productoEntity)
        {
            _mapper.Map(productoToPatch, productoEntity);
            _repository.Save();
        }
        //public ProductoDTO CreateProduct(ProductoForCreationDTO product)
        //{
        //    var productoEntity = _mapper.Map<Producto>(product);

        //    _repository.Producto.CreateProduct(productoEntity);
        //    _repository.Save();

        //    var productToReturn = _mapper.Map<ProductoDTO>(productoEntity);
        //    return productToReturn;
        //}
        //public IEnumerable<ProductoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        //{
        //    if (ids is null)
        //        throw new IdParametersBadRequestException();
        //    var productEntities = _repository.Producto.GetByIds(ids, trackChanges);
        //    if (ids.Count() != productEntities.Count())
        //        throw new CollectionByIdsBadRequestException();
        //    var companiesToReturn = _mapper.Map<IEnumerable<ProductoDTO>>(productEntities);

        //    return companiesToReturn;
        //}
        //public (IEnumerable<ProductoDTO> productos, string ids) CreateProductCollection
        //    (IEnumerable<ProductoForCreationDTO> productCollection)
        //{
        //    if (productCollection is null)
        //        throw new ProductoCollectionBadRequest();
        //    var productEntities = _mapper.Map<IEnumerable<Producto>>(productCollection);
        //    foreach (var product in productEntities)
        //    {
        //        _repository.Producto.CreateProduct(product);
        //    }
        //    _repository.Save();
        //    var productCollectionToReturn =
        //    _mapper.Map<IEnumerable<ProductoDTO>>(productEntities);
        //    var ids = string.Join(",", productCollectionToReturn.Select(c => c.ProductoId));
        //    return (products: productCollectionToReturn, ids: ids);
        //}
        //public void DeleteProduct(Guid productId, bool trackChanges)
        //{
        //    var product = _repository.Producto.GetProduct(productId, trackChanges);
        //    if (product == null)
        //        throw new ProductoNotFoundException(productId);

        //    _repository.Producto.DeleteProduct(product);
        //    _repository.Save();
        //}
        //public void UpdateProduct(Guid productId, ProductoForUpdateDTO productForUpdate, bool trackChanges)
        //{
        //    var productEntity = _repository.Producto.GetProduct(productId, trackChanges);
        //    if (productEntity == null)
        //        throw new ProductoNotFoundException(productId);

        //    _mapper.Map(productForUpdate, productEntity);
        //    _repository.Save();
        //}
    }
}
