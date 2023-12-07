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

        [HttpGet("/api/contactoProveedores/{Id:Guid}", Name = "GetContactSupplier")]
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

        [HttpGet("{Id:guid}", Name = "GetContactSupplierForSupplier")]
        public IActionResult GetContactSupplierForSupplier(Guid proveedorId, Guid Id)
        {
            var contactoProv = _service.ContactoProveedorService.GetContactSupplierForSupplier(proveedorId, Id, trackChanges: false);
            return Ok(contactoProv);
        }


        [HttpPost]
        public IActionResult CreateContactSupplierForSupplier(Guid proveedorId, [FromBody] ContactoProveedorForCreationDTO contactoProveedor)
        {
            if (contactoProveedor is null)
            {
                return BadRequest("ContactSupplierForCreationDto object is null");
            }
            var contactoProvToReturn = _service.ContactoProveedorService.CreateContactSupplierForSupplier(proveedorId, contactoProveedor, trackChanges: false);

            return CreatedAtRoute("GetContactSupplierForSupplier", new { proveedorId, Id = contactoProvToReturn.ContProvId },
                contactoProvToReturn);
        }


        [HttpDelete("{Id:guid}")]
        public IActionResult DeleteContactSupplierForSupplier(Guid proveedorId, Guid Id)
        {
            _service.ContactoProveedorService.DeleteContactSupplierForSupplier(proveedorId, Id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{Id:guid}")]
        public IActionResult UpdateContactSupplierForSupplier(Guid proveedorId, Guid Id, [FromBody] ContactoProveedorForUpdateDTO contactoProveedor)
        {
            if (contactoProveedor is null)
            {
                return BadRequest("ContactSupplierForUpdateDto object is null");
            }

            _service.ContactoProveedorService.UpdateContactSupplierForSupplier(proveedorId, Id, contactoProveedor, provTrackChanges: false, contProvTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{Id:guid}")]
        public IActionResult PartiallyUpdateContactoProveedorForProveedor(Guid proveedorId, Guid Id,
            [FromBody] JsonPatchDocument<ContactoProveedorForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.ContactoProveedorService.GetContactoProveedorForPatch(proveedorId, Id, provTrackChanges: false, contProvTrackChanges: true);
            patchDoc.ApplyTo(result.contProvToPatch);

            _service.ContactoProveedorService.SaveChangesForPatch(result.contProvToPatch, result.contProvEntity);

            return NoContent();
        }
    }
}
