using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Presentation.Controllers
{
    [Route ("api/cargo/{CargoId}/empleadoCargo")]
    [ApiController]
    public class EmpleadoCargoController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmpleadoCargoController(IServiceManager service) => _service = service;
    }
}
