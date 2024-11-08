using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Domain.Interfaces;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;

namespace KCIAO.API.MVC.Application.Services
{
    public class EventoApplicationService : IEventoApplicationService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoApplicationService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public EventoEntity? DeletarDadosEvento(string id)
        {
            return _eventoRepository.DeletarDados(id);
        }

        public EventoEntity? EditarDadosEvento(string id, EventoDto entity)
        {
            var evento = new EventoEntity
            {
                id_evento = id,
                tipo_evento = entity.tipo_evento,
                desc_evento = entity.desc_evento,
                dt_evento = entity.dt_evento,
                fk_cliente = entity.fk_cliente,
            };

            return _eventoRepository.EditarDados(evento);
        }

        public EventoEntity? ObterEventoporId(string id)
        {
            return _eventoRepository.ObterporId(id);
        }

        public IEnumerable<EventoEntity>? ObterTodasEventos()
        {
            return _eventoRepository.ObterTodos();
        }

        public EventoEntity? SalvarDadosEvento(EventoDto entity)
        {
            var evento = new EventoEntity
            {
                tipo_evento = entity.tipo_evento,
                desc_evento = entity.desc_evento,
                dt_evento = entity.dt_evento,
                fk_cliente = entity.fk_cliente,
            };

            return _eventoRepository.SalvarDados(evento);
        }
    }
}
