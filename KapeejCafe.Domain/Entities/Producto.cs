using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Entities
{
    public class Producto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioBase { get; set; }
        public bool Activo { get; set; }

        public ICollection<ProductoIngrediente> Ingredientes { get; set; } = new List<ProductoIngrediente>();
    }
}
