using KCIAO.API.MVC.Domain.Entities;

namespace KCIAO.API.MVC.Domain.Interfaces
{
    public interface IDoencaRepository
    {
        IEnumerable<DoencaEntity>? ObterTodos();
        DoencaEntity? ObterporId(string id);
        DoencaEntity? SalvarDados(DoencaEntity entity);
        DoencaEntity? EditarDados(DoencaEntity entity);
        DoencaEntity? DeletarDados(string id);
    }
}
