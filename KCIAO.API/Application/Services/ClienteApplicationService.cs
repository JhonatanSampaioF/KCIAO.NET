using KCIAO.API.Application.Dtos;
using KCIAO.API.Application.Interfaces;
using KCIAO.API.Domain.Entities;
using KCIAO.API.Domain.Interfaces;

namespace KCIAO.API.Application.Services
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

        public ClienteEntity? EditarDadosCliente(string id, ClienteDto entity)
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
