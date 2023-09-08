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
 
        [HttpGet("/api/cargos/{CargoId}/empleadoCargos")]
        public IActionResult GetEmployeesForCompany(Guid CargoId, Guid EmpleadoCargoId)
        {
            var employeesJobs = _service.EmpleadoCargoService.GetByCargo(CargoId, EmpleadoCargoId, trackChanges: false);
            return Ok(employeesJobs);
        }

        [HttpGet("/api/empleados/{EmpleadoId}/empleadoCargos")]
        public IActionResult GetByEmployee(Guid EmpleadoId, Guid EmpleadoCargoId)
        {
            var employeesJobs = _service.EmpleadoCargoService.GetByEmployee(EmpleadoId, EmpleadoCargoId, trackChanges: false);
            return Ok(employeesJobs);
        }


        [HttpPost]
        public IActionResult CreateEmployeeJobForCargoEmployee(Guid CargoId,Guid EmpleadoId, [FromBody] EmpleadoCargoForCreationDTO empleadoCargo)
        {
            if (empleadoCargo is null)
                return BadRequest("EmployeeForCreationDto object is null");

            var employeeToReturn = _service.EmpleadoCargoService.CreateEmployeeJobForCargoEmployee(CargoId, EmpleadoId, empleadoCargo, trackChanges: false);

            return CreatedAtRoute("CreateEmployeeJobForCargoEmployee", new { CargoId, EmpleadoId, id = employeeToReturn.Id },
                employeeToReturn);
        }
    }
}

