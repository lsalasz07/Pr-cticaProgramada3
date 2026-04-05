using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiquetesApp.Models;
using TiquetesApp.Services;

namespace TiquetesApp.Controllers.API
{
    [Route("api/compras")]
    [ApiController]
    [Authorize]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _service;

        public ComprasController(ICompraService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Comprar([FromBody] CompraViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, compra) = await _service.ComprarAsync(vm);

            if (!success)
                return BadRequest(new { message });

            return Ok(new
            {
                message,
                compra = new
                {
                    compra!.Id,
                    compra.EventoId,
                    compra.NombreCliente,
                    compra.Cantidad,
                    compra.Total,
                    compra.FechaCompra
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var compras = await _service.GetAllAsync();

            var resultado = compras.Select(c => new
            {
                c.Id,
                c.EventoId,
                eventoNombre = c.Evento != null ? c.Evento.Nombre : "N/A",
                c.NombreCliente,
                c.Cantidad,
                c.Total,
                c.FechaCompra
            });

            return Ok(resultado);
        }
    }
}