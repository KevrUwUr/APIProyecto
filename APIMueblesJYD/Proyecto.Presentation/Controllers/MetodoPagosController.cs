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
    [Route("api/facturaVentas/{facturaVentaId}/metodoPagos")]
    [ApiController]
    public class MetodoPagosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MetodoPagosController(IServiceManager service) => _service = service;

        [HttpGet("/api/metodoPagos")]
        public IActionResult GetAllPaymentMethods()
        {
            var metodoPago = _service.MetodoPagoService.GetAllPaymentMethods(trackChanges: false);
            return Ok(metodoPago);
        }

        [HttpGet("/api/metodoPagos/{Id:Guid}", Name = "GetPaymentMethod")]
        public IActionResult GetPaymentMethod(Guid Id)
        {
            var metPago = _service.MetodoPagoService.GetPaymentMethod(Id, trackChanges: false);
            return Ok(metPago);
        }

        [HttpGet]
        public IActionResult GetAllPaymentMethodsForSaleBill(Guid facturaVentaId)
        {
            var metodoPago = _service.MetodoPagoService.GetAllPaymentMethodsForSaleBill(facturaVentaId, trackChanges: false);
            return Ok(metodoPago);
        }

        [HttpGet("{Id:guid}", Name = "GetPaymentMethodForSaleBill")]
        public IActionResult GetPaymentMethodForSaleBill(Guid facturaVentaId, Guid Id)
        {
            var metPago = _service.MetodoPagoService.GetPaymentMethodForSaleBill(facturaVentaId, Id, trackChanges: false);
            return Ok(metPago);
        }


        [HttpPost]
        public IActionResult CreatePaymentMethodForSaleBill(Guid facturaVentaId, [FromBody] MetodoPagoForCreationDTO metodoPago)
        {
            if (metodoPago is null)
            {
                return BadRequest("PaymentMethodForCreationDto object is null");
            }
            var metPagoToReturn = _service.MetodoPagoService.CreatePaymentMethodForSaleBill(facturaVentaId, metodoPago, trackChanges: false);

            return CreatedAtRoute("GetPaymentMethodForSaleBill", new { facturaVentaId, Id = metPagoToReturn.IdMetodoPago },
                metPagoToReturn);
        }


        [HttpDelete("{Id:guid}")]
        public IActionResult DeletePaymentMethodForSaleBill(Guid facturaVentaId, Guid Id)
        {
            _service.MetodoPagoService.DeletePaymentMethodForSaleBill(facturaVentaId, Id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{Id:guid}")]
        public IActionResult UpdatePaymentMethodForSaleBill(Guid facturaVentaId, Guid Id, [FromBody] MetodoPagoForUpdateDTO metodoPago)
        {
            if (metodoPago is null)
            {
                return BadRequest("PaymentMethodForUpdateDto object is null");
            }

            _service.MetodoPagoService.UpdatePaymentMethodForSaleBill(facturaVentaId, Id, metodoPago, facVentaTrackChanges: false, metPagoTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{Id:guid}")]
        public IActionResult PartiallyUpdateMetodoPagoForProveedor(Guid facturaVentaId, Guid Id,
            [FromBody] JsonPatchDocument<MetodoPagoForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.MetodoPagoService.GetMetodoPagoForPatch(facturaVentaId, Id, facturaVentaTrackChanges: false, metPagoTrackChanges: true);
            patchDoc.ApplyTo(result.metPagoToPatch);

            _service.MetodoPagoService.SaveChangesForPatch(result.metPagoToPatch, result.metPagoEntity);

            return NoContent();
        }
    }
}
