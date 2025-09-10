using KapeejCafe.Application.Common.Interfaces;
using KapeejCafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.Products.Commands
{
    public class CrearProductoHandler : IRequestHandler<CrearProductoCommand, Guid>
    {
        private readonly IUnitiOfWork _unitOfWork;

        public CrearProductoHandler(IUnitiOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = new Producto
            {
                Id = Guid.NewGuid(),
                Nombre = request.ProductoDto.Nombre,
                Descripcion = request.ProductoDto.Descripcion,
                PrecioBase = request.ProductoDto.PrecioBase
            };

            foreach (var ingDto in request.ProductoDto.Ingredientes)
            {
                // Traer ingrediente existente
                var ingrediente = await _unitOfWork.Ingredientes.GetByIdAsync(ingDto.IngredienteId);
                if (ingrediente == null)
                    throw new Exception($"Ingrediente con Id {ingDto.IngredienteId} no existe.");

                var productoIngrediente = new ProductoIngrediente
                {
                    ProductoId = producto.Id,
                    IngredienteId = ingDto.IngredienteId,
                    EsOpcional = ingDto.EsOpcional,
                    EsObligatorio = ingDto.EsObligatorio,
                    CostoExtra =  ingDto.CostoExtra,
                    Descripcion = ingDto.Descripcion ?? ingrediente.Nombre
                };

                producto.Ingredientes.Add(productoIngrediente);
            }

            await _unitOfWork.Productos.AddAsync(producto);
            await _unitOfWork.CompleteAsync();

            return producto.Id;
        }
    }
}
