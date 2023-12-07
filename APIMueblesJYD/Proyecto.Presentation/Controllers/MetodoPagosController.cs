using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyect.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
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
            var metodoPagos = _service.MetodoPagoService.GetAllPaymentMethods(trackChanges: false);
            return Ok(metodoPagos);
        }

        [HttpGet("/api/metodoPagos/{id:Guid}", Name = "GetPaymentMethod")]
        public IActionResult GetPaymentMethod(Guid Id)
        {
            var metodoPago = _service.MetodoPagoService.GetPaymentMethod(Id, trackChanges: false);
            return Ok(metodoPago);
        }

        [HttpGet]
        public IActionResult GetAllPaymentMethodsForSaleBill(Guid facturaVentaId)
        {
            var facVentas = _service.MetodoPagoService.GetAllPaymentMethodsForSaleBill(facturaVentaId, trackChanges: false);
            return Ok(facVentas);
        }

        [HttpGet("{id:guid}", Name = "GetPaymentMethodForSaleBill")]
        public IActionResult GetPaymentMethodForSaleBill(Guid facturaVentaId, Guid id)
        {
            var contactoEmp = _service.MetodoPagoService.GetPaymentMethodForSaleBill(facturaVentaId, id, trackChanges: false);
            return Ok(contactoEmp);
        }

        [HttpPost]
        public IActionResult CreatePaymentMethodForSaleBill(Guid facturaVentaId, [FromBody] MetodoPagoForCreationDTO paymentMethod)
        {
            if (paymentMethod == null)
            {
                return BadRequest("MetodoPagoForCreationDTO object is null");
            }
            var createdPaymentMethod = _service.MetodoPagoService.CreatePaymentMethodForSaleBill(facturaVentaId, paymentMethod, trackChanges: false);

            return CreatedAtRoute("GetPaymentMethod", new { id = createdPaymentMethod.IdMetodoPago },
            createdPaymentMethod);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePaymentMethodForSaleBill(Guid facturaVentaId, Guid id)
        {
            _service.MetodoPagoService.DeletePaymentMethodForSaleBill(facturaVentaId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePaymentMethodForSaleBill(Guid facturaVentaId, Guid Id, [FromBody] MetodoPagoForUpdateDTO paymentMethod)
        {
            if (paymentMethod is null)
            {
                return BadRequest("paymentMethodForUpdateDTO object is null");
            }

            _service.MetodoPagoService.UpdatePaymentMethodForSaleBill(facturaVentaId, Id, paymentMethod, facVentaTrackChanges: true, metPagoTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{Id:guid}")]
        public IActionResult PartiallyUpdateMetodoPagoForMetodoPago(Guid metodoPagoId, Guid Id,
            [FromBody] JsonPatchDocument<MetodoPagoForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.MetodoPagoService.GetMetodoPagoForPatch(metodoPagoId, Id, facturaVentaTrackChanges: false, metPagoTrackChanges: true);
            patchDoc.ApplyTo(result.metPagoToPatch);

            _service.MetodoPagoService.SaveChangesForPatch(result.metPagoToPatch, result.metPagoEntity);

            return NoContent();
        }
    }
}
