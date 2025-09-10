using KapeejCafe.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.Products.Commands
{
    public class CrearProductoCommand : IRequest<Guid>
    {
        public CrearProductoDto ProductoDto { get; set; } = null!;
    }
}
