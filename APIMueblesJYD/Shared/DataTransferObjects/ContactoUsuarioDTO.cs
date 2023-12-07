using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoUsuarioDTO
    {
        public Guid ContUsuarioId { get; init; }
        public string? NumeroTelefonico { get; init; }
        public string? IndicativoCiudad { get; init; }
        public string? TipoTelefono { get; init; }
        public string? Direccion { get; init; }
        public string? Ciudad { get; init; }
        public string? Barrio_Localidad { get; init; }
        public string? Email { get; init; }
        public Guid IdUsuario { get; init; }
    }
}
