using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Producto
    {
        [Column("IdProducto")]
        [Key]
        public Guid IdProducto { get; set; }

        [Required(ErrorMessage = "Nombre es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public float Precio { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Descripcion es un campo requerido.")]
        [MaxLength(300, ErrorMessage = "Largo maximo del nombre es de 300 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Estado { get; set; }

        [Required(ErrorMessage = "Color es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Tipo { get; set; }

        public string? OrigenMateriaPrima { get; set; }

        [ForeignKey(nameof(Categoria))]
        public Guid IdCategoria { get; set; }
        public Categoria? Categoria{ get; set; }
        public ICollection<HistoricoPrecios>? HistoricoPrecios { get; set; }
        public ICollection<DetalleFacturaCompra>? detalleFacturaCompras { get; set; }
        public ICollection<Perdida_Producto>? perdida_Productos { get; set; }
        public ICollection<DetalleFacturaVenta>? detalleFacturaVentas { get; set; }
    }
}
