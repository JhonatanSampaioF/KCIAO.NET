using KCIAO.API.Application.Dtos;
using KCIAO.API.Domain.Entities;

namespace KCIAO.API.Application.Interfaces
{
    public interface IClienteApplicationService
    {
        IEnumerable<ClienteEntity>? ObterTodosClientes();
        ClienteEntity? ObterClienteporId(string id);
        ClienteEntity? SalvarDadosCliente(ClienteDto entity);
        ClienteEntity? EditarDadosCliente(string id, ClienteDto entity);
        ClienteEntity? DeletarDadosCliente(string id);
    }
}
