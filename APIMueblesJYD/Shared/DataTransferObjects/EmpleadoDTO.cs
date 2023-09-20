using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmpleadoDTO
    {
        public Guid EmpleadoId { get; init; }
        public string? Nombres { get; init;}
        public string? Apellidos { get; init;}
        public string? Sexo { get; init;}
        public DateTime FechaNacimiento { get; init; }
        public int Estado { get; init;}
    }
    
}
