using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Entities
{
    public class PedidoDetalle
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PedidoId { get; set; }
        public Guid ProductoId { get; set; }

        public int Cantidad { get; set; } = 1;
        public decimal PrecioUnitario { get; set; }

        // Derivado (no se persiste como tal; lo calculamos en app)
        public decimal Subtotal => PrecioUnitario * Cantidad;

        // Navegación
        public Pedido Pedido { get; set; } = null!;
        public Producto Producto { get; set; } = null!;
    }
}
