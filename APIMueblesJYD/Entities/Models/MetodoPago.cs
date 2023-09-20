using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class MetodoPago
    {
        [Column("IdMetodoPago")]
        [Key]
        public Guid IdMetodoPago { get; set; }

        [Required(ErrorMessage = "Fecha de Transaccion es un campo requerido.")]
        public DateTime FechaTransaccion { get; set; }

        [Required(ErrorMessage = "Tipo es un campo requerido.")]
        public int Tipo { get; set; }

        [MaxLength(80, ErrorMessage = "Largo maximo del nombre de plataforma es de 80 caracteres")]
        public string? NombrePlataforma { get; set; }

        [ForeignKey(nameof(FacturaVenta))]
        public Guid FacturaVentaId { get; set; }
        public FacturaVenta? FacturaVenta { get; set; }
    }
}
