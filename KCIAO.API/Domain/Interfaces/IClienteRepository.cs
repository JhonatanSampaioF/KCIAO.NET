using KCIAO.API.Domain.Entities;

namespace KCIAO.API.Domain.Interfaces
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
