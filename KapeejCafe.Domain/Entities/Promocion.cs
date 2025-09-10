using KapeejCafe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Entities
{
    public class Promocion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TipoPromocion Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool EsPorCumpleanios { get; set; }
        public bool Activo { get; set; } = true;
    }
}
