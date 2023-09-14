using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyect.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Proyect.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MetodoPagosController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetPaymentMethods()
        {
            var metodoPagos = _service.MetodoPagoService.GetAllPaymentMethods(trackChanges: false);
            return Ok(metodoPagos);
        }

        [HttpGet("{id:Guid}", Name = "GetPaymentMethod")]
        public IActionResult GetPaymentMethod(Guid Id)
        {
            var metodoPago = _service.MetodoPagoService.GetPaymentMethod(Id, trackChanges: false);
            return Ok(metodoPago);
        }
        [HttpPost]
        public IActionResult CreatePaymentMethod([FromBody] MetodoPagoForCreationDTO paymentMethod)
        {
            if (paymentMethod == null)
            {
                return BadRequest("MetodoPagoForCreationDTO object is null");
            }
            var createdPaymentMethod = _service.MetodoPagoService.CreatePaymentMethod(paymentMethod);

            return CreatedAtRoute("GetPaymentMethod", new { id = createdPaymentMethod.IdMetodoPago },
            createdPaymentMethod);
        }

        [HttpGet("collection/({ids})", Name = "PaymentMethodCollection")]
        public IActionResult GetpaymentMethodCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var categories = _service.MetodoPagoService.GetByIds(ids, trackChanges: false);
            return Ok(categories);
        }

        [HttpPost("collection")]
        public IActionResult CreatePaymentMethodCollection([FromBody]
        IEnumerable<MetodoPagoForCreationDTO> paymentMethodCollection)
        {
            var result =
            _service.MetodoPagoService.CreatePaymentMethodCollection(paymentMethodCollection);
            return CreatedAtRoute("PaymentMethodCollection", new { result.ids },
            result.metodoPagos);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePaymentMethod(Guid id)
        {
            _service.MetodoPagoService.DeletePaymentMethod(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePaymentMethod(Guid id, [FromBody] MetodoPagoForUpdateDTO paymentMethod)
        {
            if (paymentMethod == null)
                return BadRequest("paymentMethodForUpdateDTO object is null");

            _service.MetodoPagoService.UpdatePaymentMethod(id, paymentMethod, trackChanges: true);
            return NoContent();
        }
    }
}
