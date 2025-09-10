using FluentValidation;
using KapeejCafe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.Products.Validators
{
    public class CrearProductoValidator : AbstractValidator<CrearProductoDto>
    {
        public CrearProductoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.PrecioBase)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El precio debe ser mayor a 0.");

            RuleForEach(x => x.Ingredientes)
                .SetValidator(new IngredienteProductoValidator());
             
        }        
    }

    public class IngredienteProductoValidator : AbstractValidator<IngredienteProductoDto>
    {
        public IngredienteProductoValidator()
        {
            RuleFor(x => x.IngredienteId)
                .NotEmpty().WithMessage("El Id del Ingrediente es obligatorio.");

            RuleFor(x => x.CostoExtra)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El costo extra no puede ser negativo.");
        }
    }
}
