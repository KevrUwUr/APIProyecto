using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proyect.Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProveedoresController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            var proveedores = _service.ProveedorService.GetAllSuppliers(trackChanges: false);
            return Ok(proveedores);
        }

        [HttpGet("{id:Guid}", Name = "GetSupplier")]
        public IActionResult GetSupplier(Guid Id)
        {
            var proveedor = _service.ProveedorService.GetSupplier(Id, trackChanges: false);
            return Ok(proveedor);
        }
        [HttpPost]
        public IActionResult CreateSupplier([FromBody] ProveedorForCreationDTO proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest("ProveedorForCreationDTO object is null");
            }
            var createdProveedor = _service.ProveedorService.CreateSupplier(proveedor);

            return CreatedAtRoute("GetSupplier", new { id = createdProveedor.IdProveedor },
            createdProveedor);
        }

        [HttpGet("collection/({ids})", Name = "ProveedorCollection")]
        public IActionResult GetProveedorCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var suppliers = _service.ProveedorService.GetByIds(ids, trackChanges: false);
            return Ok(suppliers);
        }

        [HttpPost("collection")]
        public IActionResult CreateProveedorCollection([FromBody]
        IEnumerable<ProveedorForCreationDTO> ProveedorCollection)
        {
            var result =
            _service.ProveedorService.CreateSupplierCollection(ProveedorCollection);
            return CreatedAtRoute("ProveedorCollection", new { result.ids },
            result.proveedores);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProveedor(Guid id)
        {
            _service.ProveedorService.DeleteSupplier(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateProveedor(Guid id, [FromBody] ProveedorForUpdateDTO Proveedor)
        {
            if (Proveedor == null)
                return BadRequest("ProveedorForUpdateDTO object is null");

            _service.ProveedorService.UpdateSupplier(id, Proveedor, trackChanges: true);
            return NoContent();
        }
    }
}
