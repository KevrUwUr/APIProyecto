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
    [Route("api/usuarios/{usuarioId}/contactoUsuarios")]
    [ApiController]
    public class ContactoUsuariosController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ContactoUsuariosController(IServiceManager service) => _service = service;

        [HttpGet("/api/contactoUsuarios")]
        public IActionResult GetAllContactUsers()
        {
            var usuarios = _service.ContactoUsuarioService.GetAllUserContacts(trackChanges: false);
            return Ok(usuarios);
        }

        [HttpGet("/api/contactoUsuarios/{id:Guid}", Name = "GetContactUser")]
        public IActionResult GetContactUser(Guid Id)
        {
            var contactoUsuario = _service.ContactoUsuarioService.GetUserContact(Id, trackChanges: false);
            return Ok(contactoUsuario);
        }

        [HttpGet]
        public IActionResult GetAllContactUsersForUser(Guid usuarioId)
        {
            var usuarios = _service.ContactoUsuarioService.GetAllContactUsersForUser(usuarioId, trackChanges: false);
            return Ok(usuarios);
        }

        [HttpGet("{id:guid}", Name = "GetContactUserForUser")]
        public IActionResult GetContactUserForUser(Guid usuarioId, Guid id)
        {
            var contactoUsuario = _service.ContactoUsuarioService.GetContactUserForUser(usuarioId, id, trackChanges: false);
            return Ok(contactoUsuario);
        }


        [HttpPost]
        public IActionResult CreateContactUserForUser(Guid usuarioId, [FromBody] ContactoUsuarioForCreationDTO contactoUsuario)
        {
            if (contactoUsuario is null)
            {
                return BadRequest("ContactUserForCreationDto object is null");
            }
            var contactoUsuarioToReturn = _service.ContactoUsuarioService.CreateContactUserForUser(usuarioId, contactoUsuario, trackChanges: false);

            return CreatedAtRoute("GetContactUserForUser", new { usuarioId, id = contactoUsuarioToReturn.ContUsuarioId },
                contactoUsuarioToReturn);
        }


        [HttpDelete("{id:guid}")]
        public IActionResult DeleteContactUserForUser(Guid usuarioId, Guid id)
        {
            _service.ContactoUsuarioService.DeleteContactUserForUser(usuarioId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateContactUserForUser(Guid usuarioId, Guid id, [FromBody] ContactoUsuarioForUpdateDTO contactoUsuario)
        {
            if (contactoUsuario is null)
            {
                return BadRequest("ContactUserForUpdateDto object is null");
            }

            _service.ContactoUsuarioService.UpdateContactUserForUser(usuarioId, id, contactoUsuario, usuarioTrackChanges: false, contUsuarioTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateContactoUsuarioForUsuario(Guid usuarioId, Guid id,
            [FromBody] JsonPatchDocument<ContactoUsuarioForUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.ContactoUsuarioService.GetContactoUsuarioForPatch(usuarioId, id, usuarioTrackChanges: false, contUsuarioTrackChanges: true);
            patchDoc.ApplyTo(result.contUsuarioToPatch);

            _service.ContactoUsuarioService.SaveChangesForPatch(result.contUsuarioToPatch, result.contUsuarioEntity);

            return NoContent();
        }
    }
}
