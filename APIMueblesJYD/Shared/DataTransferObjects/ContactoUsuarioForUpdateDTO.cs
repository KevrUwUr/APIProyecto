using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ContactoUsuarioForUpdateDTO(string NumeroTelefonico, string IndicativoCiudad, 
        string TipoTelefono, string Direccion, string Ciudad, string Barrio_Localidad, string Email);
}
