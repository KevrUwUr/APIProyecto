using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Perdida
    {
        [Column("IdPerdida")]
        [Key]
        public int IdPerdida { get; set; }

        [Required(ErrorMessage = "Fecha de Perdida es un campo requerido.")]
        public DateTime FechaPerdida { get; set; }

        [Required(ErrorMessage = "Tipo es un campo requerido.")]
        public int Estado { get; set; }

        [Required(ErrorMessage = "Total es un campo requerido.")]
        public float Total { get; set; }
        public ICollection<Perdida_Producto>? perdida_Productos { get; set; }

        [ForeignKey(nameof(Empleado))]
        public int IdEmpleado { get; set; }
        public Empleado? Empleado { get; set; }
    }
}
