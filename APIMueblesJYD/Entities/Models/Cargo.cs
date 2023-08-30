using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cargo
    {
        [Column("CargoId")]
        [Key]
        public int CargoId { get; set; }

        [Required(ErrorMessage = "NombreCargo es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]

        public string? NombreCargo { get; set; }

        [Required(ErrorMessage = "Estado es un campo requerido.")]
        public int Estado { get; set; }

        public List<EmpleadoCargo>? EmpleadoCargos { get; set; }
    }
}