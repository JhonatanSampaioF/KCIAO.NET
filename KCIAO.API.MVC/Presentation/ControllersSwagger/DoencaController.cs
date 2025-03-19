using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KCIAO.API.MVC.Presentation.ControllersSwagger
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoencaController : ControllerBase
    {
        private readonly IDoencaApplicationService _doencaApplicationService;
        public DoencaController(IDoencaApplicationService doencaApplicationService)
        {
            _doencaApplicationService = doencaApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos as doenças", Description = "Este endpoint retorna uma lista completa de todas as doenças cadastradas.")]
        [Produces(typeof(IEnumerable<ClienteEntity>))]
        public IActionResult Get()
        {
            try
            {
                var doencas = _doencaApplicationService.ObterTodasDoencas();

                if (doencas is null)
                    return NoContent();

                return Ok(doencas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma doença específica", Description = "Este endpoint retorna os detalhes de uma doença específica com base no ID fornecido.")]
        [SwaggerResponse(200, "Doença encontrado com sucesso", typeof(ClienteEntity))]
        [SwaggerResponse(204, "Doença não encontrado")]
        [SwaggerResponse(404, "Falha para obter o doença")]
        public IActionResult ObterPorId(string id)
        {
            try
            {
                var doenca = _doencaApplicationService.ObterDoencaporId(id);

                if (doenca is null)
                    return NoContent();

                return Ok(doenca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova doença", Description = "Este endpoint cria uma nova doença com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Doença criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir a doença")]
        [Produces(typeof(ClienteEntity))]
        public IActionResult Post([FromBody] DoencaDto entity)
        {
            try
            {
                var doenca = _doencaApplicationService.SalvarDadosDoenca(entity);

                return Ok(doenca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma doença existente", Description = "Este endpoint atualiza as informações de uma doença com base no ID fornecido.")]
        [SwaggerResponse(200, "Doença atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar a doença")]
        [Produces(typeof(ClienteEntity))]
        public IActionResult Put(string id, [FromBody] DoencaEditDto entity)
        {
            try
            {
                var doenca = _doencaApplicationService.EditarDadosDoenca(id, entity);

                return Ok(doenca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove uma doença existente", Description = "Este endpoint remove as informações de uma doença com base no ID fornecido.")]
        [SwaggerResponse(200, "Doença removida com sucesso")]
        [SwaggerResponse(404, "Falha para excluir a doença")]
        [Produces(typeof(ClienteEntity))]
        public IActionResult Delete(string id)
        {
            try
            {
                var doenca = _doencaApplicationService.DeletarDadosDoenca(id);

                return Ok(doenca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
