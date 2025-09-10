using KapeejCafe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Entities
{
    public class HistorialPuntos
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ClienteId { get; set; }
        public Guid? PedidoId { get; set; }       // Nullable: carga/abono sin pedido
        public int Puntos { get; set; }           // Positivo=ganados, negativo=redimidos
        public TipoHistorial Tipo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public string? Motivo { get; set; }       // Opcional: “Promo cumpleaños”, etc.

        // Navegación
        public Cliente Cliente { get; set; } = null!;
        public Pedido? Pedido { get; set; }
    }
}
