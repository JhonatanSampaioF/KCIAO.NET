using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Domain.Interfaces;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;

namespace KCIAO.API.MVC.Application.Services
{
    public class ClienteDoencaApplicationService : IClienteDoencaApplicationService
    {
        private readonly IClienteDoencaRepository _clienteDoencaRepository;

        public ClienteDoencaApplicationService(IClienteDoencaRepository clienteDoencaRepository)
        {
            _clienteDoencaRepository = clienteDoencaRepository;
        }

        public ClienteDoenca? DeletarDadosClienteDoenca(string fk_cliente, string fk_doenca)
        {
            return _clienteDoencaRepository.DeletarDados(fk_cliente, fk_doenca);
        }

        public ClienteDoenca? EditarDadosClienteDoenca(string fk_cliente, string fk_doenca, ClienteDoencaDto entity)
        {
            var clienteDoenca = new ClienteDoenca
            {
                fk_cliente = entity.fk_cliente,
                fk_doenca = entity.fk_doenca
            };

            return _clienteDoencaRepository.EditarDados(clienteDoenca);
        }

        public ClienteDoenca? ObterClienteDoencaporId(string fk_cliente, string fk_doenca)
        {
            return _clienteDoencaRepository.ObterporId(fk_cliente, fk_doenca);
        }

        public IEnumerable<ClienteDoenca>? ObterTodasClienteDoencas()
        {
            return _clienteDoencaRepository.ObterTodos();
        }

        public ClienteDoenca? SalvarDadosClienteDoenca(ClienteDoencaDto entity)
        {
            var clienteDoenca = new ClienteDoenca
            {
                fk_cliente = entity.fk_cliente,
                fk_doenca = entity.fk_doenca
            };

            return _clienteDoencaRepository.SalvarDados(clienteDoenca);
        }
    }
}
