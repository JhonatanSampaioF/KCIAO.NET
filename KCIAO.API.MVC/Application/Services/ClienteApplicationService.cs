using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Domain.Interfaces;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplicationService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteEntity? DeletarDadosCliente(string id)
        {
            return _clienteRepository.DeletarDados(id);
        }

        public ClienteEntity? EditarDadosCliente(string id, ClienteEditDto entity)
        {
            var cliente = new ClienteEntity
            {
                id_cliente = id,
                nm_cliente = entity.nm_cliente
            };

            return _clienteRepository.EditarDados(cliente);
        }

        public ClienteEntity? ObterClienteporId(string id)
        {
            return _clienteRepository.ObterporId(id);
        }

        public IEnumerable<ClienteEntity>? ObterTodosClientes()
        {
            return _clienteRepository.ObterTodos();
        }

        public ClienteEntity? SalvarDadosCliente(ClienteDto entity)
        {
            var cliente = new ClienteEntity
            {
                nm_cliente = entity.nm_cliente
            };

            return _clienteRepository.SalvarDados(cliente);
        }
    }
}
