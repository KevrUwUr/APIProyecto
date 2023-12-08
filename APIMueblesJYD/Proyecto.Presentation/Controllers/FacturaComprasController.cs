using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Proyect.Presentation.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace Proyect.Presentation.Controllers
{
    [Route("api/proveedores/{proveedorId}/facturaCompras")]
    [ApiController]
    public class FacturaComprasController : ControllerBase
    {
        private readonly IServiceManager _service;
        public FacturaComprasController(IServiceManager service) => _service = service;

        [HttpGet("/api/facturaCompras")]
        public IActionResult GetAllBuyBills()
        {
            var facturaCompra = _service.FacturaCompraService.GetAllBuyBills(trackChanges: false);
            return Ok(facturaCompra);
        }

        [HttpGet("/api/facturaCompras/{id:Guid}", Name = "GetBuyBill")]
        public IActionResult GetBuyBill(Guid Id)
        {
            var facCompra = _service.FacturaCompraService.GetBuyBill(Id, trackChanges: false);
            return Ok(facCompra);
        }

        [HttpGet]
        public IActionResult GetAllBuyBillsForSupplier(Guid proveedorId)
        {
            var proveedores = _service.FacturaCompraService.GetAllBuyBillsForSupplier(proveedorId, trackChanges: false);
            return Ok(proveedores);
        }

        [HttpGet("{id:guid}", Name = "GetBuyBillForSupplier")]
        public IActionResult GetBuyBillForSupplier(Guid proveedorId, Guid id)
        {
            var facCompra = _service.FacturaCompraService.GetBuyBillForSupplier(proveedorId, id, trackChanges: false);
            return Ok(facCompra);
        }

        [HttpPost]
        public IActionResult CreateBuyBillForSupplier(Guid proveedorId, [FromBody] FacturaCompraForCreationDTO factCompra)
        {
            if (factCompra is null)
            {
                return BadRequest("BuyBillForCreationDto object is null");
            }
            var facCompraToReturn = _service.FacturaCompraService.CreateBuyBillForSupplier(proveedorId, factCompra, trackChanges: false);

            return CreatedAtRoute("GetBuyBillForSupplier", new { proveedorId, id = facCompraToReturn.FacturaCompraId },
                facCompraToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBuyBillForSupplier(Guid proveedorId, Guid id)
        {
            _service.FacturaCompraService.DeleteBuyBillForSupplier(proveedorId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBuyBillForSupplier(Guid proveedorId, Guid id, [FromBody] FacturaCompraForUpdateDTO factCompra)
        {
            if (factCompra is null)
            {
                return BadRequest("BuyBillForUpdateDto object is null");
            }

            _service.FacturaCompraService.UpdateBuyBillForSupplier(proveedorId, id, factCompra, proveedorTrackChanges: false, facCompraTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateFacturaCompraForProveedor(Guid proveedorId, Guid id,
            [FromBody] JsonPatchDocument<FacturaCompraForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.FacturaCompraService.GetFacturaCompraForPatch(proveedorId, id, proveedorTrackChanges: false, facCompraTrackChanges: true);
            patchDoc.ApplyTo(result.facCompraToPatch);

            _service.FacturaCompraService.SaveChangesForPatch(result.facCompraToPatch, result.facCompraEntity);

            return NoContent();
        }
    }
}
