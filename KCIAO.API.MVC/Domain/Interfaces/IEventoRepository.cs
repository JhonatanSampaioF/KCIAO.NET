namespace KCIAO.API.MVC.Domain.Entities
{
    public interface IEventoRepository
    {
        IEnumerable<EventoEntity>? ObterTodos();
        EventoEntity? ObterporId(string id);
        EventoEntity? SalvarDados(EventoEntity entity);
        EventoEntity? EditarDados(EventoEntity entity);
        EventoEntity? DeletarDados(string id);
    }
}
