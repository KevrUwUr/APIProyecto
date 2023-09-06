using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Usuario
    {
        [Column("IdUsuario")]
        [Key]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Primer Nombre de usuario es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del primer nombre es de 80 caracteres")]
        public string? PrimNombre { get; set; }

        [MaxLength(80, ErrorMessage = "Largo maximo del segundo nombre es de 80 caracteres")]
        public string? SegNombre { get; set; }

        [Required(ErrorMessage = "Primer Apellido de usuario es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del primer apellido es de 80 caracteres")]
        public string? PrimApellido { get; set; }

        [MaxLength(80, ErrorMessage = "Largo maximo del segundo apellido es de 80 caracteres")]
        public string? SegApellido { get; set; }

        [Required(ErrorMessage = "Sexo de usuario es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo de sexo es de 80 caracteres")]
        public string? Sexo { get; set; }

        [Required(ErrorMessage = "Tipo Documento de usuario es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del Tipo de Documento es de 80 caracteres")]
        public string? TipoDocumento { get; set; }

        [Required(ErrorMessage = "Numero Documento es un campo requerido.")]
        public int NumDocumento { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento es un campo requerido.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Estado es un campo requerido.")]
        public int Estado { get; set; }

        [Required(ErrorMessage = "Fecha de Registro es un campo requerido.")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "Tipo de Usuario es un campo requerido.")]
        public int TipoUsuario { get; set; }

        public DateTime FechaContrato { get; set; }

        [MaxLength(80, ErrorMessage = "Largo maximo del cargo es de 80 caracteres")]
        public string? Cargo { get; set; }

        public DateTime FechaFin { get; set; }

        public string? Contrasena { get; set; }

        [MaxLength(80, ErrorMessage = "Largo maximo de llave es de 80 caracteres")]
        public string? Llave { get; set; }
        public ICollection<ContactoUsuario>? contactoUsuarios { get; set; }
        public ICollection<FacturaVenta>? facturaVentas { get; set; }
    }
}
