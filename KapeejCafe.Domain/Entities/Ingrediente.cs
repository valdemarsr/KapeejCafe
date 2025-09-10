using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Entities
{
    public class Ingrediente
    {
        public Guid Id { get; set; }
        public String Nombre { get; set; }
        public string? Descripcion { get; set; }

        public ICollection<ProductoIngrediente> Productos { get; set; } = new List<ProductoIngrediente>();
    }
}
