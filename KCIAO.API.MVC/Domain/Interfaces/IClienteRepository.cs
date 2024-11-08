namespace KCIAO.API.MVC.Domain.Entities
{
    public interface IClienteRepository
    {
        IEnumerable<ClienteEntity>? ObterTodos();
        ClienteEntity? ObterporId(string id);
        ClienteEntity? SalvarDados(ClienteEntity entity);
        ClienteEntity? EditarDados(ClienteEntity entity);
        ClienteEntity? DeletarDados(string id);
    }
}
