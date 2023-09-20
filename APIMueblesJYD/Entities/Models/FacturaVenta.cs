using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class FacturaVenta
    {
        [Column("FacturaVentaId")]
        [Key]
        public Guid FacturaVentaId { get; set; }

        [Required(ErrorMessage = "NFactura es un campo requerido.")]
        public int NFactura { get; set; }

        [Required(ErrorMessage = "FechaGeneracion es un campo requerido.")]
        public DateTime? FechaGeneracion { get; set; }

        [Required(ErrorMessage = "FechaExpedicion es un campo requerido.")]
        public DateTime? FechaExpedicion { get; set; }

        [Required(ErrorMessage = "FechaVencimiento es un campo requerido.")]
        public DateTime? FechaVencimiento { get; set; }

        [Required(ErrorMessage = "TotalBruto es un campo requerido.")]
        public float TotalBruto { get; set; }

        [Required(ErrorMessage = "TotalIVA es un campo requerido.")]
        public float TotalIVA { get; set; }

        [Required(ErrorMessage = "TotalRefuete es un campo requerido.")]
        public float TotalRefuete { get; set; }

        [Required(ErrorMessage = "TotalPago es un campo requerido.")]
        public float TotalPago { get; set; }

        [ForeignKey(nameof(Usuario))]
        public Guid IdUsuario  { get; set; }
        public Usuario? Usuarios { get; set; }

        public ICollection<MetodoPago>? MetodoPago { get; set;}
    }
}
