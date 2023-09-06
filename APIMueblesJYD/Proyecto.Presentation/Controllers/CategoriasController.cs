using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Proyect.Presentation.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriasController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetCategories()
        {

            var cargos = _service.CategoriaService.GetAllCategories(trackChanges: false);
            return Ok(cargos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategory(Guid Id)
        {
            var cargo = _service.CategoriaService.GetCategory(Id, trackChanges: false);
            return Ok(cargo);
        }
    }
}
