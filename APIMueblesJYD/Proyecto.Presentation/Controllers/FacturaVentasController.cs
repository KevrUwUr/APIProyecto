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
    [Route("api/usuarios/{usuarioId}/facturaVentas")]
    [ApiController]
    public class FacturaVentasController : ControllerBase
    {
        private readonly IServiceManager _service;
        public FacturaVentasController(IServiceManager service) => _service = service;

        [HttpGet("/api/facturaVentas")]
        public IActionResult GetAllSaleBills()
        {
            var facturaVenta = _service.FacturaVentaService.GetAllSaleBills(trackChanges: false);
            return Ok(facturaVenta);
        }

        [HttpGet("/api/facturaVentas/{id:Guid}", Name = "GetSaleBill")]
        public IActionResult GetSaleBill(Guid Id)
        {
            var facVenta = _service.FacturaVentaService.GetSaleBill(Id, trackChanges: false);
            return Ok(facVenta);
        }

        [HttpGet]
        public IActionResult GetAllSaleBillsForUser(Guid usuarioId)
        {
            var usuarios = _service.FacturaVentaService.GetAllSaleBillsForUser(usuarioId, trackChanges: false);
            return Ok(usuarios);
        }

        [HttpGet("{id:guid}", Name = "GetSaleBillForUser")]
        public IActionResult GetSaleBillForUser(Guid usuarioId, Guid id)
        {
            var facVenta = _service.FacturaVentaService.GetSaleBillForUser(usuarioId, id, trackChanges: false);
            return Ok(facVenta);
        }

        [HttpPost]
        public IActionResult CreateSaleBillForUser(Guid usuarioId, [FromBody] FacturaVentaForCreationDTO saleBill)
        {
            if (saleBill is null)
            {
                return BadRequest("SaleBillForCreationDto object is null");
            }
            var facVentaToReturn = _service.FacturaVentaService.CreateSaleBillForUser(usuarioId, saleBill, trackChanges: false);

            return CreatedAtRoute("GetSaleBillForUser", new { usuarioId, id = facVentaToReturn.FacturaVentaId },
                facVentaToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteSaleBillForUser(Guid usuarioId, Guid id)
        {
            _service.FacturaVentaService.DeleteSaleBillForUser(usuarioId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateSaleBillForUser(Guid usuarioId, Guid id, [FromBody] FacturaVentaForUpdateDTO saleBill)
        {
            if (saleBill is null)
            {
                return BadRequest("SaleBillForUpdateDto object is null");
            }

            _service.FacturaVentaService.UpdateSaleBillForUser(usuarioId, id, saleBill, usuarioTrackChanges: false, facVentaTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateFacturaVentaForUsuario(Guid usuarioId, Guid id,
            [FromBody] JsonPatchDocument<FacturaVentaForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.FacturaVentaService.GetFacturaVentaForPatch(usuarioId, id, usuarioTrackChanges: false, facVentaTrackChanges: true);
            patchDoc.ApplyTo(result.facVentaToPatch);

            _service.FacturaVentaService.SaveChangesForPatch(result.facVentaToPatch, result.facVentaEntity);

            return NoContent();
        }
    }
}
