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
    public class UsuariosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UsuariosController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var usuarios = _service.UsuarioService.GetAllUsers(trackChanges: false);
            return Ok(usuarios);
        }

        [HttpGet("{id:Guid}", Name = "GetUser")]
        public IActionResult GetUser(Guid Id)
        {
            var usuario = _service.UsuarioService.GetUser(Id, trackChanges: false);
            return Ok(usuario);
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UsuarioForCreationDTO usuario)
        {
            if (usuario == null)
            {
                return BadRequest("UsuarioForCreationDTO object is null");
            }
            var createdUsuario = _service.UsuarioService.CreateUser(usuario);

            return CreatedAtRoute("GetUser", new { id = createdUsuario.IdUsuario },
            createdUsuario);
        }

        [HttpGet("collection/({ids})", Name = "UsuarioCollection")]
        public IActionResult GetUsuarioCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var suppliers = _service.UsuarioService.GetByIds(ids, trackChanges: false);
            return Ok(suppliers);
        }

        [HttpPost("collection")]
        public IActionResult CreateUsuarioCollection([FromBody]
        IEnumerable<UsuarioForCreationDTO> UsuarioCollection)
        {
            var result =
            _service.UsuarioService.CreateUserCollection(UsuarioCollection);
            return CreatedAtRoute("UsuarioCollection", new { result.ids },
            result.usuarios);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUsuario(Guid id)
        {
            _service.UsuarioService.DeleteUser(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUsuario(Guid id, [FromBody] UsuarioForUpdateDTO Usuario)
        {
            if (Usuario == null)
                return BadRequest("UsuarioForUpdateDTO object is null");

            _service.UsuarioService.UpdateUser(id, Usuario, trackChanges: true);
            return NoContent();
        }
    }
}
