using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Empleado_Cargo
    {
        [Required(ErrorMessage = "FechaInicio es un campo requerido.")]
        public DateOnly? FechaInicio { get; set; }

        [Required(ErrorMessage = "FechaFin es un campo requerido.")]
        public DateOnly? FechaFin { get; set; }

        [Required(ErrorMessage = "NumeroContrato es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo de  NumeroContrato es de 80 caracteres")]
        public int? NumeroContrato { get; set; }

        [ForeignKey(nameof(Empleado))]
        public Guid IdEmpleado { get; set; }
        public Empleado? Empleado { get; set; }

        [ForeignKey(nameof(Cargo))]
        public Guid idCargo { get; set; }
        public Cargo? Cargos { get; set; }

    }
}
