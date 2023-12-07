using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proyect.Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerdidasController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PerdidasController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAllLoses()
        {
            var perdidas = _service.PerdidaService.GetAllLoses(trackChanges: false);
            return Ok(perdidas);
        }

        [HttpGet("{id:Guid}", Name = "GetLose")]
        public IActionResult GetLose(Guid Id)
        {
            var proveedor = _service.PerdidaService.GetLose(Id, trackChanges: false);
            return Ok(proveedor);
        }
        [HttpPost]
        public IActionResult CreateLose([FromBody] PerdidaForCreationDTO Perdida)
        {
            if (Perdida == null)
            {
                return BadRequest("PerdidaForCreationDTO object is null");
            }
            var createdPerdida = _service.PerdidaService.CreateLose(Perdida);

            return CreatedAtRoute("GetLose", new { id = createdPerdida.IdPerdida },
            createdPerdida);
        }

        [HttpGet("collection/({ids})", Name = "PerdidaCollection")]
        public IActionResult GetPerdidaCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var loses = _service.PerdidaService.GetByIds(ids, trackChanges: false);
            return Ok(loses);
        }

        [HttpPost("collection")]
        public IActionResult CreatePerdidaCollection([FromBody]
        IEnumerable<PerdidaForCreationDTO> PerdidaCollection)
        {
            var result =
            _service.PerdidaService.CreateLoseCollection(PerdidaCollection);
            return CreatedAtRoute("PerdidaCollection", new { result.ids },
            result.perdidas);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePerdida(Guid id)
        {
            _service.PerdidaService.DeleteLose(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePerdida(Guid id, [FromBody] PerdidaForUpdateDTO Perdida)
        {
            if (Perdida == null)
                return BadRequest("PerdidaForUpdateDTO object is null");

            _service.PerdidaService.UpdateLose(id, Perdida, trackChanges: true);
            return NoContent();
        }
    }
}
