using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class HistoricoPrecios
    {
        [Column("IdHistoricoPrecios")]
        [Key]
        public Guid IdHistoricoPrecios { get; set; }

        [Required(ErrorMessage = "PresioVenta es un campo requerido.")]
        public float PresioVenta { get; set; }

        [Required(ErrorMessage = "FechaPrecioInicial es un campo requerido.")]
        public DateOnly? FechaPrecioInicial { get; set; }

        [Required(ErrorMessage = "FechaPrecioFinal es un campo requerido.")]
        public DateOnly? FechaPrecioFinal { get; set; }

        [Required(ErrorMessage = "Estado es un campo requerido.")]
        public int Estado { get; set; }

        [ForeignKey(nameof(Producto))]
        public Guid IdProducto { get; set; }
        public Producto? Producto { get; set; }
    }
}
