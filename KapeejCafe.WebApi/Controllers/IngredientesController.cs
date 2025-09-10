using KapeejCafe.Application.DTOs;
using KapeejCafe.Application.Ingredientes.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KapeejCafe.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] IngredienteDto ingredienteDto)
        {
            var command = new CrearIngredienteCommand { IngredienteDto = ingredienteDto };
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Crear), new { id }, id);
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromServices] KapeejCafe.Infrastructure.Persistence.KapeejCafeDbContext context)
        {
            var ingredientes = await context.Ingredientes.ToListAsync();
            return Ok(ingredientes);
        }
    }
}
