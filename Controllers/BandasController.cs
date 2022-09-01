using Exercicios.Data.Dtos;
using Exercicios.Models;
using Exercicios.Repositories;
using Exercicios.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandasController : ControllerBase
    {
        private readonly BandaService _service;

        public BandasController(BandaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<ReadBandaDto> bandas = _service.Get();

                return bandas.Any() ? Ok(bandas) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                ReadBandaDto? model = _service.GetById(id);

                return model != null ? Ok(model) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Post(CreateBandaDto createBandaDto)
        {
            try
            {
                ReadBandaDto readBandaDto = _service.Post(createBandaDto);

                return CreatedAtAction(nameof(GetById), new { Id = readBandaDto.Id }, readBandaDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateBandaDto bandaDto)
        {
            try
            {
                bool hasBeenUpdated = _service.Put(id, bandaDto);

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
                bool hasBeenDeleted = _service.Delete(id);

                return hasBeenDeleted ? NoContent() : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
