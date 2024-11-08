using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Infraestructure.Data.AppData;

namespace KCIAO.API.MVC.Infraestructure.Data.Repositories
{
    public class ClienteDoencaRepository : IClienteDoencaRepository
    {
        private readonly ApplicationContext _context;

        public ClienteDoencaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ClienteDoenca? DeletarDados(string fk_cliente, string fk_doenca)
        {
            try
            {
                var clienteDoenca = _context.ClienteDoenca
                    .FirstOrDefault(cd => cd.fk_cliente == fk_cliente && cd.fk_doenca == fk_doenca);

                if (clienteDoenca is not null)
                {
                    _context.Remove(clienteDoenca);
                    _context.SaveChanges();

                    return clienteDoenca;
                }
                throw new Exception("Não foi possível localizar o clienteDoenca ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ClienteDoenca? EditarDados(ClienteDoenca entity)
        {
            try
            {
                var clienteDoenca = _context.ClienteDoenca
                    .FirstOrDefault(cd => cd.fk_cliente == entity.fk_cliente && cd.fk_doenca == entity.fk_doenca);

                if (clienteDoenca is not null)
                {
                    clienteDoenca.fk_cliente = entity.fk_cliente;
                    clienteDoenca.fk_doenca = entity.fk_doenca;

                    _context.Update(clienteDoenca);
                    _context.SaveChanges();

                    return clienteDoenca;
                }

                throw new Exception("Não foi possível localizar o clienteDoenca ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ClienteDoenca? ObterporId(string fk_cliente, string fk_doenca)
        {
            var clienteDoenca = _context.ClienteDoenca
                .FirstOrDefault(cd => cd.fk_cliente == fk_cliente && cd.fk_doenca == fk_doenca);

            if (clienteDoenca is not null)
            {
                return clienteDoenca;
            }
            return null;
        }

        public IEnumerable<ClienteDoenca>? ObterTodos()
        {
            var clienteDoencas = _context.ClienteDoenca.ToList();

            if (clienteDoencas.Any())
                return clienteDoencas;

            return null;
        }

        public ClienteDoenca? SalvarDados(ClienteDoenca entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o clienteDoenca ");
            }
        }
    }
}
