using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Application.Dtos;

namespace KCIAO.API.MVC.Application.Interfaces
{
    public interface IClienteDoencaApplicationService
    {
        IEnumerable<ClienteDoenca>? ObterTodasClienteDoencas();
        ClienteDoenca? ObterClienteDoencaporId(string fk_cliente, string fk_doenca);
        ClienteDoenca? SalvarDadosClienteDoenca(ClienteDoencaDto entity);
        ClienteDoenca? EditarDadosClienteDoenca(string fk_cliente, string fk_doenca, ClienteDoencaDto entity);
        ClienteDoenca? DeletarDadosClienteDoenca(string fk_cliente, string fk_doenca);
    }
}
