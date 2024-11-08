using KCIAO.API.MVC.Domain.Entities;

namespace KCIAO.API.MVC.Domain.Interfaces
{
    public interface IConsultaRepository
    {
        IEnumerable<ConsultaEntity>? ObterTodos();
        ConsultaEntity? ObterporId(string id);
        ConsultaEntity? SalvarDados(ConsultaEntity entity);
        ConsultaEntity? EditarDados(ConsultaEntity entity);
        ConsultaEntity? DeletarDados(string id);
    }
}
