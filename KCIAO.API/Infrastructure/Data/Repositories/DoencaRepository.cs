using KCIAO.API.Domain.Entities;
using KCIAO.API.Domain.Interfaces;
using KCIAO.API.Infrastructure.Data.AppData;

namespace KCIAO.API.Infrastructure.Data.Repositories
{
    public class DoencaRepository : IDoencaRepository
    {
        private readonly ApplicationContext _context;

        public DoencaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public DoencaEntity? DeletarDados(string id)
        {
            try
            {
                var doenca = _context.Doenca.Find(id);

                if (doenca is not null)
                {
                    _context.Remove(doenca);
                    _context.SaveChanges();

                    return doenca;
                }
                throw new Exception("Não foi possível localizar a doença ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public DoencaEntity? EditarDados(DoencaEntity entity)
        {
            try
            {
                var doenca = _context.Doenca.Find(entity.id_doenca);

                if (doenca is not null)
                {
                    doenca.nm_doenca = entity.nm_doenca;

                    _context.Update(doenca);
                    _context.SaveChanges();

                    return doenca;
                }

                throw new Exception("Não foi possível localizar a doença ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public DoencaEntity? ObterporId(string id)
        {
            var doenca = _context.Doenca.Find(id);

            if (doenca is not null)
            {
                return doenca;
            }
            return null;
        }

        public IEnumerable<DoencaEntity>? ObterTodos()
        {
            var doencas = _context.Doenca.ToList();

            if (doencas.Any())
                return doencas;

            return null;
        }

        public DoencaEntity? SalvarDados(DoencaEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar a doença ");
            }
        }
    }
}
