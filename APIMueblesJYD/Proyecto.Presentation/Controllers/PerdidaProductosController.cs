﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proyect.Presentation.Controllers
{
    [Route("api/perdidas/{perdidaId}/productos/{productoId}")]
    [ApiController]
    public class PerdidaProductosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PerdidaProductosController(IServiceManager service) => _service = service;

        [HttpGet("/api/perdidaProductos")]
        public IActionResult GetAllLoseProducts()
        {
            var perdidaProductos = _service.PerdidaProductoService.GetAllLoseProducts(trackChanges: false);
            return Ok(perdidaProductos);
        }

        [HttpGet("/api/perdidaProductos/{id:Guid}", Name = "GetLoseProduct")]
        public IActionResult GetLoseProduct(Guid Id)
        {
            var proveedor = _service.PerdidaProductoService.GetLoseProduct(Id, trackChanges: false);
            return Ok(proveedor);
        }

        [HttpGet("/api/perdidas/{perdidaId}/perdidaproductos")]
        public IActionResult GetAllLoseProductsForLose(Guid perdidaId)
        {
            var perdidaLoseProductos = _service.PerdidaProductoService.GetAllLoseProductsByLose(perdidaId, trackChanges: false);
            return Ok(perdidaLoseProductos);
        }

        //[HttpGet("/api/perdidas/{perdidaId}/perdidaproductos/{id:Guid}", Name = "GetLoseProductForLose")]
        //public IActionResult GetLoseProductForLose(Guid perdidaId, Guid id)
        //{
        //    var perdidaLoseProducto = _service.PerdidaProductoService.GetLoseProductByLose(perdidaId, trackChanges: false);
        //    return Ok(perdidaLoseProducto);
        //}


        //[HttpPost]
        //public IActionResult CreateLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, [FromBody] PerdidaProductoForCreationDTO perdidaProducto)
        //{
        //    if (perdidaProducto is null)
        //    {
        //        return BadRequest("LoseProductForCreationDTO object is null");
        //    }
        //    var perdidaProductoToReturn = _service.PerdidaProductoService.CreateLoseProductForLoseAndProduct(perdidaId, productoId, perdidaProducto, trackChanges: false);

        //    return CreatedAtRoute("GetLoseProductForLose", new { perdidaId, productoId }, perdidaProductoToReturn);
        //}

        [HttpGet]
        public IActionResult GetLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId)
        {
            var proveedor = _service.PerdidaProductoService.GetLoseProductForLoseAndProduct(perdidaId, productoId, trackChanges: false);
            return Ok(proveedor);
        }



        [HttpDelete]
        public IActionResult DeleteLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId)
        {
            _service.PerdidaProductoService.DeleteLoseProductForLose(perdidaId, productoId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateLoseProductForLose(Guid perdidaId, Guid productoId, Guid id, [FromBody] PerdidaProductoForUpdateDTO perdidaProducto)
        {
            if (perdidaProducto is null)
            {
                return BadRequest("LoseProductForUpdateDTO object is null");
            }

            _service.PerdidaProductoService.UpdateLoseProductForLoseAndProduct(perdidaId, productoId, perdidaProducto, perdProdTrackChanges: false, perdTrackChanges: true, prodTrackChanges: true);
            return NoContent();
        }

        /**/

        [HttpGet("/api/productos/{productoId}/perdidaproductos")]
        public IActionResult GetAllPerdidaProductosForProduct(Guid productoId)
        {
            var perdidaProducto = _service.PerdidaProductoService.GetAllLoseProductsByProduct(productoId, trackChanges: false);
            return Ok(perdidaProducto);
        }

        //[HttpGet("/api/productos/{productoId}/perdidaproductos/{id:Guid}", Name = "GetPerdidaProductoForProduct")]
        //public IActionResult GetPerdidaProductoForProduct(Guid productoId, Guid id)
        //{
        //    var perdidaProducto = _service.PerdidaProductoService.GetLoseProductByProduct(productoId, id, trackChanges: false);
        //    return Ok(perdidaProducto);
        //}

        //[HttpGet("/api/perdidas/{perdidaId}/perdidaproductos")]
        //public IActionResult GetAllLoseProductsForLoseAndProduct(Guid perdidaId)
        //{
        //    var perdidaLoseProductos = _service.PerdidaProductoService.GetAllLoseProductsForLoseAndProduct(perdidaId, trackChanges: false);
        //    return Ok(perdidaLoseProductos);
        //}

        //[HttpGet("/api/perdidas/{perdidaId}/perdidaproductos/{id:Guid}", Name = "GetLoseProductForLose")]
        //public IActionResult GetLoseProductForLoseAndProduct(Guid perdidaId, Guid ProductoId)
        //{
        //    var perdidaLoseProducto = _service.PerdidaProductoService.GetLoseProductForLoseAndProduct(perdidaId, ProductoId, trackChanges: false);
        //    return Ok(perdidaLoseProducto);
        //}
    }
}
