using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Proyecto.Presentation.Controllers
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
            try
            {
                var cargos =
                _service.CargoService.GetAllCargos(trackChanges: false);
                return Ok(cargos);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
