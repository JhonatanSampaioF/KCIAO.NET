using KCIAO.API.MVC.Domain.Entities;

namespace KCIAO.API.MVC.Domain.Interfaces
{
    public interface IClienteDoencaRepository
    {
        IEnumerable<ClienteDoenca>? ObterTodos();
        ClienteDoenca? ObterporId(string fk_cliente, string fk_doenca);
        ClienteDoenca? SalvarDados(ClienteDoenca entity);
        ClienteDoenca? EditarDados(ClienteDoenca entity);
        ClienteDoenca? DeletarDados(string fk_cliente, string fk_doenca);
    }
}
