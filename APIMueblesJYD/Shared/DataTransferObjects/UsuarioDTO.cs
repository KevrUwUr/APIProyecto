using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UsuarioDTO
    {
        public Guid IdUsuario { get; init; }
        public string? PrimNombre { get; init; }
        public string? SegNombre { get; init; }
        public string? PrimApellido { get; init; }
        public string? SegApellido { get; init; }
        public string? Sexo { get; init; }
        public string? TipoDocumento { get; init; }
        public int NumDocumento { get; init; }
        public DateTime FechaNacimiento { get; init; }
        public int Estado { get; init; }
        public DateTime FechaRegistro { get; init; }
        public int TipoUsuario { get; init; }
        public DateTime FechaContrato { get; init; }
        public string? Cargo { get; init; }
        public DateTime FechaFin { get; init; }
        public string? Contrasena { get; init; }
        public string? Llave { get; init; }
    }
}
