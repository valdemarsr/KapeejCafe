using KapeejCafe.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.Ingredientes.Commands
{
    public class CrearIngredienteCommand : IRequest<Guid>
    {
        public IngredienteDto IngredienteDto { get; set; } = null!;
    }
}
