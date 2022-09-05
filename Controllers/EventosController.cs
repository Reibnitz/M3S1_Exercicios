using Exercicios.Data.Dtos.Evento;
using Exercicios.Models;
using Exercicios.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly EventoService _eventoService;

        public EventosController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<ReadEventoDto> eventos = _eventoService.Get();
                return eventos.Any() ? Ok(eventos) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Post(CreateEventoDto createEventoDto)
        {
            try
            {
                ReadEventoDto readEventoDto = _eventoService.Post(createEventoDto);

                return CreatedAtAction(nameof(Get), new { Id = readEventoDto.Id}, readEventoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateEventoDto updateEventoDto)
        {
            try
            {
                bool hasBeenUpdated = _eventoService.Put(id, updateEventoDto);

                return hasBeenUpdated ? NoContent() : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool hasBeenDeleted = _eventoService.Delete(id);
        
                return hasBeenDeleted ? NoContent() : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
