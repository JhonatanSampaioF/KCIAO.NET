using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Application.Interfaces
{
    public interface IEventoApplicationService
    {
        IEnumerable<EventoEntity>? ObterTodasEventos();
        EventoEntity? ObterEventoporId(string id);
        EventoEntity? SalvarDadosEvento(EventoDto entity);
        EventoEntity? EditarDadosEvento(string id, EventoEditDto entity);
        EventoEntity? DeletarDadosEvento(string id);
    }
}
