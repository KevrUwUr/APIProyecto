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
    [Route("api/proveedores/{proveedorId}/contactoProveedores")]
    [ApiController]
    public class ContactoProveedoresController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ContactoProveedoresController(IServiceManager service) => _service = service;

        [HttpGet("/api/contactoProveedores")]
        public IActionResult GetAllContactSuppliers()
        {
            var proveedores = _service.ContactoProveedorService.GetAllSupplierContacts(trackChanges: false);
            return Ok(proveedores);
        }

        [HttpGet("/api/contactoProveedores/{id:Guid}", Name = "GetContactSupplier")]
        public IActionResult GetContactSupplier(Guid Id)
        {
            var contactoProv = _service.ContactoProveedorService.GetSupplierContact(Id, trackChanges: false);
            return Ok(contactoProv);
        }

        [HttpGet]
        public IActionResult GetAllContactSuppliersForSupplier(Guid proveedorId)
        {
            var proveedores = _service.ContactoProveedorService.GetAllContactSuppliersForSupplier(proveedorId, trackChanges: false);
            return Ok(proveedores);
        }

        [HttpGet("{id:guid}", Name = "GetContactSupplierForSupplier")]
        public IActionResult GetContactSupplierForSupplier(Guid proveedorId, Guid id)
        {
            var contactoProv = _service.ContactoProveedorService.GetContactSupplierForSupplier(proveedorId, id, trackChanges: false);
            return Ok(contactoProv);
        }
        [HttpPost]
        public IActionResult CreateContactSupplierForSupplier(Guid proveedorId, [FromBody] ContactoProveedorForCreationDTO contactoProv)
        {
            if (contactoProv is null)
            {
                return BadRequest("ContactSupplierForCreationDto object is null");
            }
            var contactoProvToReturn = _service.ContactoProveedorService.CreateContactSupplierForSupplier(proveedorId, contactoProv, trackChanges: false);

            return CreatedAtRoute("GetContactSupplierForSupplier", new { proveedorId, id = contactoProvToReturn.IdProveedor },
                contactoProvToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteContactSupplierForSupplier(Guid proveedorId, Guid id)
        {
            _service.ContactoProveedorService.DeleteContactSupplierForSupplier(proveedorId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateContactSupplierForSupplier(Guid proveedorId, Guid id, [FromBody] ContactoProveedorForUpdateDTO contactoProv)
        {
            if (contactoProv is null)
            {
                return BadRequest("ContactSupplierForUpdateDto object is null");
            }

            _service.ContactoProveedorService.UpdateContactSupplierForSupplier(proveedorId, id, contactoProv, provTrackChanges: false, contProvTrackChanges: true);
            return NoContent();
        }
    }
}
