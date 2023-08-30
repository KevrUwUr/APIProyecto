using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Empleado
    {
        [Column("EmpleadoId")]
        [Key]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "Nombres es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo de los nombres es de 80 caracteres")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo de los apellidos es de 80 caracteres")]
        public string? Apellidos { get; set; }

        [Required(ErrorMessage = "Sexo es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del sexo es de 80 caracteres")]
        public string? Sexo { get; set; }

        [Required(ErrorMessage = "FechaNacimiento es un campo requerido.")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Estado es un campo requerido.")]
        public int Estado { get; set; }

        public List<ContactoEmpleado>? ContactoEmpleados { get; set; }
        public List<EmpleadoCargo>? EmpleadoCargos { get; set; }
    }
}
