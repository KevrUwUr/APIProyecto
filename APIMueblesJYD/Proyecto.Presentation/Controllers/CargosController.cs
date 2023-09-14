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
    public class CargosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CargosController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetCargos()
        {

            var cargos = _service.CargoService.GetAllCargos(trackChanges: false);
            return Ok(cargos);
        }

        [HttpGet("{id:Guid}", Name = "GetCargo")]
        public IActionResult GetCargo(Guid Id)
        {
            var cargo = _service.CargoService.GetCargo(Id, trackChanges: false);
            return Ok(cargo);
        }

        [HttpPost]
        public IActionResult CreateCargo([FromBody] CargoForCreationDTO cargo)
        {
            if (cargo is null)
                return BadRequest("CargoForCreationDTO object is null");

            var createdCargo = _service.CargoService.CreateCargo(cargo);

            return CreatedAtRoute("GetCargo", new { id = createdCargo.Id }, createdCargo);
        }

        [HttpPost("collection")]
        public IActionResult CreateCargoCollection([FromBody] IEnumerable<CargoForCreationDTO> cargoCollection)
        {
            var result = _service.CargoService.CreateCargoCollection(cargoCollection);

            return CreatedAtRoute("CargoCollection", new { result.ids }, result.cargos);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCargo(Guid id)
        {
            _service.CargoService.DeleteCargo(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateCargo(Guid id, [FromBody] CargoForUpdateDTO cargo)
        {
            if (cargo is null)
                return BadRequest("CargoForUpdateDTO object is null");
            _service.CargoService.UpdateCargo(id, cargo, trackChanges: true);
            return NoContent();
        }
    }

}
