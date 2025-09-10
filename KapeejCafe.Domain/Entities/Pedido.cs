using KapeejCafe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClienteId { get; set; }   // FK hacia Cliente
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }
        public PedidoEstado Estado { get; set; } = PedidoEstado.Pendiente;

        public Cliente Cliente { get; set; }
        public ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
    }
}
