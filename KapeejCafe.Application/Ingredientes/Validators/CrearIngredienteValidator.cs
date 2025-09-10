using FluentValidation;
using KapeejCafe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.Ingredientes.Validators
{
    public class CrearIngredienteValidator : AbstractValidator<IngredienteDto>
    {
        public CrearIngredienteValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del ingrediente es obligatorio.")
                .MaximumLength(100);
        }
    }
}
