using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PerdidaProducto
    {
        [Column("PerdidaProductoId")]
        [Key]
        public Guid PerdidaProductoId { get; set; }
        public float PrecioUnitario { get; set; }

        [Required(ErrorMessage = "Cantidad es un campo requerido.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Motivo es un campo requerido.")]
        [MaxLength(250, ErrorMessage = "Largo maximo del motivo es de 250 caracteres")]

        public string? Motivo { get; set; }

        [ForeignKey(nameof(Perdida))]
        public Guid IdPerdida { get; set; }
        public Perdida? Perdida { get; set; }

        [ForeignKey(nameof(Producto))]
        public Guid ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
