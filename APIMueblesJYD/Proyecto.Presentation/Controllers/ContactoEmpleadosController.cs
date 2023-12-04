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
    [Route("api/empleados/{empleadoId}/contactoEmpleados")]
    [ApiController]
    public class ContactoEmpleadosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ContactoEmpleadosController(IServiceManager service) => _service = service;

        [HttpGet("/api/contactoEmpleados")]
        public IActionResult GetAllContactEmployees()
        {
            var empleados = _service.ContactoEmpleadoService.GetAllEmployeeContacts(trackChanges: false);
            return Ok(empleados);
        }

        [HttpGet("/api/contactoEmpleados/{id:Guid}", Name = "GetContactEmployee")]
        public IActionResult GetContactEmployee(Guid Id)
        {
            var contactoEmp = _service.ContactoEmpleadoService.GetEmployeeContact(Id, trackChanges: false);
            return Ok(contactoEmp);
        }

        [HttpGet]
        public IActionResult GetAllContactEmployeesForEmployee(Guid empleadoId)
        {
            var empleadoes = _service.ContactoEmpleadoService.GetAllContactEmployeesForEmployee(empleadoId, trackChanges: false);
            return Ok(empleadoes);
        }

        [HttpGet("{id:guid}", Name = "GetContactEmployeeForEmployee")]
        public IActionResult GetContactEmployeeForEmployee(Guid empleadoId, Guid id)
        {
            var contactoEmp = _service.ContactoEmpleadoService.GetContactEmployeeForEmployee(empleadoId, id, trackChanges: false);
            return Ok(contactoEmp);
        }


        [HttpPost]
        public IActionResult CreateContactEmployeeForEmployee(Guid empleadoId, [FromBody] ContactoEmpleadoForCreationDTO contactoEmpleado)
        {
            if (contactoEmpleado is null)
            {
                return BadRequest("ContactEmployeeForCreationDto object is null");
            }
            var contactoEmpToReturn = _service.ContactoEmpleadoService.CreateContactEmployeeForEmployee(empleadoId, contactoEmpleado, trackChanges: false);

            return CreatedAtRoute("GetContactEmployeeForEmployee", new { empleadoId, id = contactoEmpToReturn.ContEmpId },
                contactoEmpToReturn);
        }


        [HttpDelete("{id:guid}")]
        public IActionResult DeleteContactEmployeeForEmployee(Guid empleadoId, Guid id)
        {
            _service.ContactoEmpleadoService.DeleteContactEmployeeForEmployee(empleadoId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateContactEmployeeForEmployee(Guid empleadoId, Guid id, [FromBody] ContactoEmpleadoForUpdateDTO contactoEmpleado)
        {
            if (contactoEmpleado is null)
            {
                return BadRequest("ContactEmployeeForUpdateDto object is null");
            }

            _service.ContactoEmpleadoService.UpdateContactEmployeeForEmployee(empleadoId, id, contactoEmpleado, empTrackChanges: false, contEmpTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateContactoEmpleadoForEmpleado(Guid empleadoId, Guid id,
            [FromBody] JsonPatchDocument<ContactoEmpleadoForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.ContactoEmpleadoService.GetContactoEmpleadoForPatch(empleadoId, id, empTrackChanges: false, contEmpTrackChanges: true);
            patchDoc.ApplyTo(result.contEmpToPatch);

            _service.ContactoEmpleadoService.SaveChangesForPatch(result.contEmpToPatch, result.contEmpEntity);

            return NoContent();
        }
    }
}
