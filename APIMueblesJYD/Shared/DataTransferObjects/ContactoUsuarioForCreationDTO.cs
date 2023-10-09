using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoUsuarioForCreationDTO (int NumeroTelefonico, string IndicativoCiudad, string Direccion,
        string Ciudad, string Barrio_Localidad, string Email, int IdUsuario);
}
