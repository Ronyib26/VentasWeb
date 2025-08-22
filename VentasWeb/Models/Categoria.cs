using System.ComponentModel.DataAnnotations;

namespace VentasWeb.Models
{
    public class Categoria
    {
        [Key]
        public int CodigoCategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}