using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Proyect.Presentation.Controllers
{
    [Route("api/empleados")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmpleadoController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetEmployee()
        {

            var empleados = _service.EmpleadoService.GetAllEmployees(trackChanges: false);
            return Ok(empleados);
        }

        [HttpGet("{id:Guid}", Name = "GetEmployee")]
        public IActionResult GetEmployee(Guid Id)
        {
            var empleado = _service.EmpleadoService.GetEmployee(Id, trackChanges: false);
            return Ok(empleado);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmpleadoForCreationDTO empleado)
        {
            if (empleado is null)
                return BadRequest("EmpleadoForCreationDTO object is null");

            var createdEmpleado = _service.EmpleadoService.CreateEmployee(empleado);

            return CreatedAtRoute("EmpleadoById", new { id = createdEmpleado.EmpleadoId }, createdEmpleado);
        }

        [HttpPost("collection")]
        public IActionResult CreateEmployeeCollection([FromBody] IEnumerable<EmpleadoForCreationDTO> empleadoCollection)
        {
            var result = _service.EmpleadoService.CreateEmployeeCollection(empleadoCollection);

            return CreatedAtRoute("EmpleadoCollection", new { result.ids }, result.empleados);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            _service.EmpleadoService.DeleteEmployee(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] EmpleadoForUpdateDTO empleado)
        {
            if (empleado is null)
                return BadRequest("EmpleadoForUpdateDTO object is null");
            _service.EmpleadoService.UpdateEmployee(id, empleado, trackChanges: true);
            return NoContent();
        }
    }
}
