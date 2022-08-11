using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
      
                public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
           
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos =  await _eventoService.GetAllEventosAsync(true);
                if (eventos == null) return NotFound("Nenhum evento encontrdo.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erroao tentar recuperar evento. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento =  await _eventoService.GetAllEventoByIdAsync(id, true);
                if (evento == null) return NotFound("Evento por ID não encontrdo.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erroao tentar recuperar evento. Erro: {ex.Message}");
            }
        }

         [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento =  await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null) return NotFound("Eventos por tema não encontrados.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erroao tentar recuperar evento. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento =  await _eventoService.AddEventos(model);
                if (evento == null) return BadRequest("Erroao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erroao tentar adicionar evento. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
           try
            {
                var evento =  await _eventoService.UpdateEvento(id,model);
                if (evento == null) return BadRequest("Erroao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erroao tentar atualizar evento. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           try
            {
                return await _eventoService.DeleteEventos(id) ? Ok("Deletado") : BadRequest("Evento não deletado");
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erroao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
    }
}
