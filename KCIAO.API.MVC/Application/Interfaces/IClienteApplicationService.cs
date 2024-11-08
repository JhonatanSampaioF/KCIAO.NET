using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Application.Interfaces
{
    public interface IClienteApplicationService
    {
        IEnumerable<ClienteEntity>? ObterTodosClientes();
        ClienteEntity? ObterClienteporId(string id);
        ClienteEntity? SalvarDadosCliente(ClienteDto entity);
        ClienteEntity? EditarDadosCliente(string id, ClienteEditDto entity);
        ClienteEntity? DeletarDadosCliente(string id);
    }
}
