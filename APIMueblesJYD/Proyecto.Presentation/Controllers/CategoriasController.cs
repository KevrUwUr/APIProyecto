using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Proyect.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Proyect.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriasController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCategories()
        {

            var categorias = _service.CategoriaService.GetAllCategories(trackChanges:false);
            return Ok(categorias);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetCategory(Guid Id)
        {
            var categoria = _service.CategoriaService.GetCategory(Id, trackChanges: false);
            return Ok(categoria);
        }
    }
}
