using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Enums
{
    public enum PedidoEstado
    {
        Pendiente = 0,
        EnPreparacion = 1,
        Listo = 2,
        Entregado = 3,
        Cancelado = 4
    }
}
