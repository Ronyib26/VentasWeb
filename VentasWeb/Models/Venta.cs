using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasWeb.Models
{
    public class Venta
    {
        [Key]
        public int CodigoVenta { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int CodigoProducto { get; set; }

        [ForeignKey("CodigoProducto")]
        public virtual Producto Producto { get; set; } = null!;
    }
}