using KapeejCafe.Application.Common.Interfaces;
using KapeejCafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.Ingredientes.Commands
{
    public class CrearIngredienteHandler : IRequestHandler<CrearIngredienteCommand, Guid>
    {
        private readonly IUnitiOfWork _unitOfWork;

        public CrearIngredienteHandler(IUnitiOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearIngredienteCommand request, CancellationToken cancellationToken)
        {
            var ingrediente = new Ingrediente
            {
                Id = Guid.NewGuid(),
                Nombre = request.IngredienteDto.Nombre,
                Descripcion = request.IngredienteDto.Descripcion
            };

            await _unitOfWork.Ingredientes.AddAsync(ingrediente);
            await _unitOfWork.CompleteAsync();

            return ingrediente.Id;

        }

    }
}
