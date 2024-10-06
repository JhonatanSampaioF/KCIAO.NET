using KCIAO.API.Application.Dtos;
using KCIAO.API.Application.Interfaces;
using KCIAO.API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KCIAO.API.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationService;
        public ClienteController(IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os clientes", Description = "Este endpoint retorna uma lista completa de todos os clientes cadastrados.")]
        [Produces(typeof(IEnumerable<ClienteEntity>))]
        public IActionResult Get()
        {
            try
            {
                var clientes = _clienteApplicationService.ObterTodosClientes();

                if (clientes is null)
                    return NoContent();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um cliente específico", Description = "Este endpoint retorna os detalhes de um cliente específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Cliente encontrado com sucesso", typeof(ClienteEntity))]
        [SwaggerResponse(204, "Cliente não encontrado")]
        [SwaggerResponse(404, "Falha para obter o cliente")]
        public IActionResult ObterPorId(string id)
        {
            try
            {
                var cliente = _clienteApplicationService.ObterClienteporId(id);

                if (cliente is null)
                    return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo cliente", Description = "Este endpoint cria um novo cliente com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Cliente criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o cliente")]
        [Produces(typeof(ClienteEntity))]
        public IActionResult Post([FromBody] ClienteDto entity)
        {
            try
            {
                var cliente = _clienteApplicationService.SalvarDadosCliente(entity);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um cliente existente", Description = "Este endpoint atualiza as informações de um cliente com base no ID fornecido.")]
        [SwaggerResponse(200, "Cliente atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o cliente")]
        [Produces(typeof(ClienteEntity))]
        public IActionResult Put(string id, [FromBody] ClienteDto entity)
        {
            try
            {
                var cliente = _clienteApplicationService.EditarDadosCliente(id, entity);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um cliente existente", Description = "Este endpoint remove as informações de um cliente com base no ID fornecido.")]
        [SwaggerResponse(200, "Cliente removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o cliente")]
        [Produces(typeof(ClienteEntity))]
        public IActionResult Delete(string id)
        {
            try
            {
                var cliente = _clienteApplicationService.DeletarDadosCliente(id);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
