namespace KCIAO.API.MVC.Domain.Entities
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
