using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Proveedor
    {
        [Column("IdProveedor")]
        [Key]
        public Guid IdProveedor { get; set; }

        [Required(ErrorMessage = "Razon Social del proveedor es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo de la RazonSocial es de 80 caracteres")]

        public string? RazonSocial { get; set; }

        [Required(ErrorMessage = "Estado es un campo requerido.")]
        public int Estado { get; set; }
        public ICollection<FacturaCompra>? facturaCompras { get; set; }
        public ICollection<ContactoProveedor>? contactoProveedors { get; set; }
    }
}
