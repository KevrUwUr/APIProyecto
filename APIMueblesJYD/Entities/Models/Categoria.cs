using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Categoria
    {
        [Column("IdCategoria")]
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Nombre de Categoria es un campo requerido.")]
        [MaxLength(80, ErrorMessage = "Largo maximo del nombre es de 80 caracteres")]

        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Estado es un campo requerido.")]
        public int Estado { get; set; }
        public ICollection<Producto>? Productos { get; set; }
    }
}
