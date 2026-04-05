using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiquetesApp.Models;
using TiquetesApp.Services;

namespace TiquetesApp.Controllers.API
{
    [Route("api/eventos")]
    [ApiController]
    [Authorize]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _service;

        public EventosController(IEventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eventos = await _service.GetAllAsync();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _service.GetByIdAsync(id);
            if (evento == null) return NotFound(new { message = "Evento no encontrado." });
            return Ok(evento);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(evento);
            return Ok(new { message = "Evento creado.", evento });
        }
    }
}