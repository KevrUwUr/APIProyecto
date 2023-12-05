using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UsuarioForCreationDTO(string PrimNombre, string SegNombre,
        string PrimApellido, string SegApellido, string Sexo, string TipoDocumento,
        int NumDocumento, DateTime FechaNacimiento, int Estado, DateTime FechaRegistro,
        int TipoUsuario, DateTime FechaContrato, string Cargo, DateTime FechaFin,
        string Contrasena, string Llave);
}
