using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Proyect.Presentation.Controllers
{
    [Route ("api/empleadoCargos")]
    [ApiController]
    public class EmpleadoCargoController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmpleadoCargoController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetAllEmployeeJobs()
        {
            var empleadoCargos = _service.EmpleadoCargoService.GetAllEmployeeJobs(trackChanges: false);
            return Ok(empleadoCargos);
        }

        [HttpGet("{id:Guid}", Name = "GetEmployeeJob")]
        public IActionResult GetEmployeeJobs(Guid Id)
        {
            var empleadoCargo = _service.EmpleadoCargoService.GetEmployeeJob(Id, trackChanges: false);
            return Ok(empleadoCargo);
        }

        [HttpPost]
        public IActionResult CreateEmployeeJob([FromBody] EmpleadoCargoForCreationDTO empleadoCargo)
        {
            if (empleadoCargo is null)
                return BadRequest("EmpleadoCargoForCreationDTO object is null");

            var createdEmpleadoCargo = _service.EmpleadoCargoService.CreateEmployeeJob(empleadoCargo);

            return CreatedAtRoute("EmpleadoCargoById", new { id = createdEmpleadoCargo.Id }, createdEmpleadoCargo);
        }

        [HttpPost("collection")]
        public IActionResult CreateEmployeeJobCollection([FromBody] IEnumerable<EmpleadoCargoForCreationDTO> empleadoCargoCollection)
        {
            var result = _service.EmpleadoCargoService.CreateEmployeeJobCollection(empleadoCargoCollection);

            return CreatedAtRoute("EmpleadoCargoCollection", new { result.ids }, result.empleadoCargos);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeJob(Guid id)
        {
            _service.EmpleadoCargoService.DeleteEmployeeJob(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeJob(Guid id, [FromBody] EmpleadoCargoForUpdateDTO empleadoCargo)
        {
            if (empleadoCargo is null)
                return BadRequest("EmpleadoCargoForUpdateDto object is null");
            _service.EmpleadoCargoService.UpdateEmployeeJob(id, empleadoCargo, trackChanges: true);
            return NoContent();
        }
    }
}

