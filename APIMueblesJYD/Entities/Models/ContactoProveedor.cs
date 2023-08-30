using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ContactoProveedor
    {
        [Column("IdContactoProveedor")]
        [Key]
        public Guid IdContactoProveedor{ get; set; }

        [Required(ErrorMessage = "NombreProv es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? NombreProv { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "E-Mail es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Direccion es un campo requerido.")]
        public int Estado { get; set; }

        [Required(ErrorMessage = "FechaAlta es un campo requerido.")]
        public DateTime FechaAlta { get; set; }

        [Required(ErrorMessage = "FechaBaja es un campo requerido.")]
        public DateTime FechaBaja { get; set; }

        [ForeignKey(nameof(Proveedor))]
        public Guid IdProveedor { get; set; }
        public Proveedor? Proveedor { get; set; }
    }
}
