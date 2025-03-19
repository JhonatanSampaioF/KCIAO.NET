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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaApplicationService _consultaApplicationService;
        public ConsultaController(IConsultaApplicationService consultaApplicationService)
        {
            _consultaApplicationService = consultaApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os consultas", Description = "Este endpoint retorna uma lista completa de todos os consultas cadastrados.")]
        [Produces(typeof(IEnumerable<ConsultaEntity>))]
        public IActionResult Get()
        {
            try
            {
                var consultas = _consultaApplicationService.ObterTodasConsultas();

                if (consultas is null)
                    return NoContent();

                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um consulta específico", Description = "Este endpoint retorna os detalhes de um consulta específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Consulta encontrado com sucesso", typeof(ConsultaEntity))]
        [SwaggerResponse(204, "Consulta não encontrado")]
        [SwaggerResponse(404, "Falha para obter o consulta")]
        public IActionResult ObterPorId(string id)
        {
            try
            {
                var consulta = _consultaApplicationService.ObterConsultaporId(id);

                if (consulta is null)
                    return NoContent();

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo consulta", Description = "Este endpoint cria um novo consulta com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Consulta criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o consulta")]
        [Produces(typeof(ConsultaEntity))]
        public IActionResult Post([FromBody] ConsultaDto entity)
        {
            try
            {
                var consulta = _consultaApplicationService.SalvarDadosConsulta(entity);

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um consulta existente", Description = "Este endpoint atualiza as informações de um consulta com base no ID fornecido.")]
        [SwaggerResponse(200, "Consulta atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o consulta")]
        [Produces(typeof(ConsultaEntity))]
        public IActionResult Put(string id, [FromBody] ConsultaEditDto entity)
        {
            try
            {
                var consulta = _consultaApplicationService.EditarDadosConsulta(id, entity);

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um consulta existente", Description = "Este endpoint remove as informações de um consulta com base no ID fornecido.")]
        [SwaggerResponse(200, "Consulta removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o consulta")]
        [Produces(typeof(ConsultaEntity))]
        public IActionResult Delete(string id)
        {
            try
            {
                var consulta = _consultaApplicationService.DeletarDadosConsulta(id);

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
