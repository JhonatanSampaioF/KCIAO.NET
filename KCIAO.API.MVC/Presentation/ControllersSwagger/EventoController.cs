using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KCIAO.API.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoApplicationService _eventoApplicationService;
        public EventoController(IEventoApplicationService eventoApplicationService)
        {
            _eventoApplicationService = eventoApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os eventos", Description = "Este endpoint retorna uma lista completa de todos os eventos cadastrados.")]
        [Produces(typeof(IEnumerable<EventoEntity>))]
        public IActionResult Get()
        {
            try
            {
                var eventos = _eventoApplicationService.ObterTodasEventos();

                if (eventos is null)
                    return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um evento específico", Description = "Este endpoint retorna os detalhes de um evento específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Evento encontrado com sucesso", typeof(EventoEntity))]
        [SwaggerResponse(204, "Evento não encontrado")]
        [SwaggerResponse(404, "Falha para obter o evento")]
        public IActionResult ObterPorId(string id)
        {
            try
            {
                var evento = _eventoApplicationService.ObterEventoporId(id);

                if (evento is null)
                    return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo evento", Description = "Este endpoint cria um novo evento com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Evento criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o evento")]
        [Produces(typeof(EventoEntity))]
        public IActionResult Post([FromBody] EventoDto entity)
        {
            try
            {
                var evento = _eventoApplicationService.SalvarDadosEvento(entity);

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um evento existente", Description = "Este endpoint atualiza as informações de um evento com base no ID fornecido.")]
        [SwaggerResponse(200, "Evento atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o evento")]
        [Produces(typeof(EventoEntity))]
        public IActionResult Put(string id, [FromBody] EventoEditDto entity)
        {
            try
            {
                var evento = _eventoApplicationService.EditarDadosEvento(id, entity);

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um evento existente", Description = "Este endpoint remove as informações de um evento com base no ID fornecido.")]
        [SwaggerResponse(200, "Evento removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o evento")]
        [Produces(typeof(EventoEntity))]
        public IActionResult Delete(string id)
        {
            try
            {
                var evento = _eventoApplicationService.DeletarDadosEvento(id);

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
