using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Relación opcional con Identity
        public Guid? AppUserId { get; set; } // FK a Identity.User

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }

        // Sistema de puntos y lealtad
        public int Puntos { get; set; } = 0;

        // Auditoría
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<HistorialPuntos> HistorialPuntos { get; set; } = new List<HistorialPuntos>();
    }
}
