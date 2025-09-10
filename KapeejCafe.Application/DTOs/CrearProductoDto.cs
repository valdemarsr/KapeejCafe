using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.DTOs
{
    public class CrearProductoDto
    {
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public decimal PrecioBase { get; set; }
        public List<IngredienteProductoDto> Ingredientes { get; set; } = new();
    }

    public class IngredienteProductoDto
    {
        public Guid IngredienteId { get; set; }
        public bool EsObligatorio { get; set; } = false;
        public bool EsOpcional { get; set; } = true;
        public decimal CostoExtra { get; set; } = 0;        
        public string Descripcion { get; set; } = "";
    }
}
