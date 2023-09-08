using Microsoft.AspNetCore.Mvc;

using Service.Contracts;
using Proyect.Presentation.ModelBinders;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Presentation.Controllers
{
    [Route("api/categorias/{categoriaId}/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProductosController(IServiceManager service) => _service = service;

        [HttpGet("/api/productos")]
        public IActionResult GetAllProducts()
        {
            var productos = _service.ProductoService.GetAllProducts(trackChanges: false);
            return Ok(productos);
        }

        [HttpGet("/api/productos/{id:Guid}", Name = "GetProduct")]
        public IActionResult GetProduct(Guid Id)
        {
            var producto = _service.ProductoService.GetProduct(Id, trackChanges: false);
            return Ok(producto);
        }

        [HttpGet]
        public IActionResult GetAllProductsForCategory(Guid categoriaId)
        {
            var productos = _service.ProductoService.GetProductsCategory(categoriaId, trackChanges: false);
            return Ok(productos);
        }

        [HttpGet("{id:guid}", Name = "GetProductForCategory")]
        public IActionResult GetProductForCategory(Guid categoriaId, Guid id)
        {
            var producto = _service.ProductoService.GetProductCategory(categoriaId, id, trackChanges: false);
            return Ok(producto);
        }
        [HttpPost]
        public IActionResult CreateProductForCategory(Guid categoriaId, [FromBody] ProductoForCreationDTO producto)
        {
            if (producto is null)
            {
                return BadRequest("ProductForCreationDto object is null");
            }
            var productoToReturn = _service.ProductoService.CreateProductForCategory(categoriaId, producto, trackChanges: false);

            return CreatedAtRoute("GetProductForCategory", new { categoriaId, id = productoToReturn.ProductoId },
                productoToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProductForCategory(Guid categoriaId, Guid id)
        {
            _service.ProductoService.DeleteProductForCategory(categoriaId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateProductForCategory(Guid categoriaId, Guid id, [FromBody] ProductoForUpdateDTO producto)
        {
            if (producto is null)
            {
                return BadRequest("ProductForUpdateDto object is null");
            }

            _service.ProductoService.UpdateProductForCategory(categoriaId, id, producto, catTrackChanges: false, prodTrackChanges: true);
            return NoContent();
        }

        //[HttpPost]
        //public IActionResult CreateProduct([FromBody] ProductoForCreationDTO Producto)
        //{
        //    if (Producto == null)
        //    {
        //        return BadRequest("ProductoForCreationDTO object is null");
        //    }
        //    var createdProducto = _service.ProductoService.CreateProduct(Producto);

        //    return CreatedAtRoute("ProductoById", new { id = createdProducto.ProductoId },
        //    createdProducto);
        //}

        //[HttpGet("collection/({ids})", Name = "ProductoCollection")]
        //public IActionResult GetProductoCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        //{
        //    var products = _service.ProductoService.GetByIds(ids, trackChanges: false);
        //    return Ok(products);
        //}

        //[HttpPost("collection")]
        //public IActionResult CreateProductoCollection([FromBody]
        //IEnumerable<ProductoForCreationDTO> ProductoCollection)
        //{
        //    var result =
        //    _service.ProductoService.CreateProductCollection(ProductoCollection);
        //    return CreatedAtRoute("ProductoCollection", new { result.ids },
        //    result.productos);
        //}

        //[HttpDelete("{id:guid}")]
        //public IActionResult DeleteProducto(Guid id)
        //{
        //    _service.ProductoService.DeleteProduct(id, trackChanges: false);
        //    return NoContent();
        //}

        //[HttpPut("{id:guid}")]
        //public IActionResult UpdateProducto(Guid id, [FromBody] ProductoForUpdateDTO Producto)
        //{
        //    if (Producto == null)
        //        return BadRequest("ProductoForUpdateDTO object is null");

        //    _service.ProductoService.UpdateProduct(id, Producto, trackChanges: true);
        //    return NoContent();
        //}
    }
}
