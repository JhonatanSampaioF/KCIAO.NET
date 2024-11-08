using KCIAO.API.MVC.Domain.Interfaces;
using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Infraestructure.Data.AppData;

namespace KCIAO.API.MVC.Infraestructure.Data.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationContext _context;

        public EventoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public EventoEntity? DeletarDados(string id)
        {
            try
            {
                var evento = _context.Evento.Find(id);

                if (evento is not null)
                {
                    _context.Remove(evento);
                    _context.SaveChanges();

                    return evento;
                }
                throw new Exception("Não foi possível localizar o evento ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public EventoEntity? EditarDados(EventoEntity entity)
        {
            try
            {
                var evento = _context.Evento.Find(entity.id_evento);

                if (evento is not null)
                {
                    evento.tipo_evento = entity.tipo_evento;
                    evento.desc_evento = entity.desc_evento;
                    evento.dt_evento = entity.dt_evento;
                    evento.fk_cliente = entity.fk_cliente;

                    _context.Update(evento);
                    _context.SaveChanges();

                    return evento;
                }

                throw new Exception("Não foi possível localizar o evento ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public EventoEntity? ObterporId(string id)
        {
            var evento = _context.Evento.Find(id);

            if (evento is not null)
            {
                return evento;
            }
            return null;
        }

        public IEnumerable<EventoEntity>? ObterTodos()
        {
            var eventos = _context.Evento.ToList();

            if (eventos.Any())
                return eventos;

            return null;
        }

        public EventoEntity? SalvarDados(EventoEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o evento ");
            }
        }
    }
}
