using KapeejCafe.Application.DTOs;
using KapeejCafe.Application.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KapeejCafe.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProductoDto productoDto)
        {
            var command = new CrearProductoCommand { ProductoDto = productoDto };
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Crear), new { id }, id);
        }
    }
}
