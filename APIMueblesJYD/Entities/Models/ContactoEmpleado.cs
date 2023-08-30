using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ContactoEmpleado
    {
        [Column("IdContactoEmpleado")]
        [Key]
        public int IdContactoEmpleado { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Direccion es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]

        public string? Direccion { get; set; }

        [Required(ErrorMessage = "E-Mail es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]

        public string? Email { get; set; }

        [Required(ErrorMessage = "Estado es un campo requerido.")]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey(nameof(Empleado))]
        public int IdEmpleado { get; set; }
        public Empleado? Empleado { get; set; }

    }
}
