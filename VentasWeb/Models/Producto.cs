using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasWeb.Models
{
    public class Producto
    {
        [Key]
        public int CodigoProducto { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int CodigoCategoria { get; set; }

        [ForeignKey("CodigoCategoria")]
        public virtual Categoria Categoria { get; set; } = null!;

        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}