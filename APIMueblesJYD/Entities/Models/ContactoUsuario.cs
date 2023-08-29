using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ContactoUsuario
    {
        [Column("IdContactoCliente")]
        [Key]
        public Guid IdContactoCliente { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public int NumeroTelefonico { get; set; }

        [Required(ErrorMessage = "NombreProv es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? NombreProv { get; set; }

        [Required(ErrorMessage = "IndicativoCiudad es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? IndicativoCiudad { get; set; }

        [Required(ErrorMessage = "TipoTelefono es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? TipoTelefono { get; set; }

        [Required(ErrorMessage = "Direccion es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Ciudad es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? Ciudad { get; set; }

        [Required(ErrorMessage = "Barrio_Localidad es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? Barrio_Localidad { get; set; }

        [Required(ErrorMessage = "E-Mail es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? Email { get; set; }

        [ForeignKey(nameof(Usuario))]
        public Guid IdUsuario { get; set; }
        public Usuario? Usuario{ get; set; }
    }
}
