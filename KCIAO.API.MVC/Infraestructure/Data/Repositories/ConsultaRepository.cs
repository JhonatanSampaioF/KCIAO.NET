using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Infraestructure.Data.AppData;

namespace KCIAO.API.MVC.Infraestructure.Data.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ApplicationContext _context;

        public ConsultaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ConsultaEntity? DeletarDados(string id)
        {
            try
            {
                var consulta = _context.Consulta.Find(id);

                if (consulta is not null)
                {
                    _context.Remove(consulta);
                    _context.SaveChanges();

                    return consulta;
                }
                throw new Exception("Não foi possível localizar a consulta ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ConsultaEntity? EditarDados(ConsultaEntity entity)
        {
            try
            {
                var consulta = _context.Consulta.Find(entity.id_consulta);

                if (consulta is not null)
                {
                    consulta.profissional = entity.profissional;
                    consulta.local_consulta = entity.local_consulta;
                    consulta.horario_consulta = entity.horario_consulta;
                    consulta.fk_evento = entity.fk_evento;

                    _context.Update(consulta);
                    _context.SaveChanges();

                    return consulta;
                }

                throw new Exception("Não foi possível localizar a consulta ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ConsultaEntity? ObterporId(string id)
        {
            var consulta = _context.Consulta.Find(id);

            if (consulta is not null)
            {
                return consulta;
            }
            return null;
        }

        public IEnumerable<ConsultaEntity>? ObterTodos()
        {
            var consultas = _context.Consulta.ToList();

            if (consultas.Any())
                return consultas;

            return null;
        }

        public ConsultaEntity? SalvarDados(ConsultaEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar a consulta ");
            }
        }
    }
}
