using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Domain.Entities
{
    public class ProductoIngrediente
    {
        public Guid ProductoId { get; set; }
        public Producto Producto { get; set; }
        public Guid IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public bool EsObligatorio { get; set; }
        public bool EsOpcional { get; set; }
        public Decimal CostoExtra { get; set; }
        public string Descripcion { get; set; } = "";
    }
}
