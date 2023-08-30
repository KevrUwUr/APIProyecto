using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DetalleFacturaVenta
    {
        [Column("DetalleFacturaVentaID")]
        [Key]
        public int DetalleFacturaVentaID { get; set; }

        [Required(ErrorMessage = "ValorUnitario es un campo requerido.")]
        public float ValorUnitario { get; set; }

        [Required(ErrorMessage = "Cantidad es un campo requerido.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "IVA es un campo requerido.")]
        public float IVA { get; set; }

        [Required(ErrorMessage = "ValorDescuento es un campo requerido.")]
        public float ValorDescuento { get; set; }

        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        public Producto? Producto { get; set; }

        [ForeignKey(nameof(FacturaVenta))]
        public int IdFacturaVenta { get; set; }
        public FacturaVenta? FacturasVenta { get; set; }
    }
}
