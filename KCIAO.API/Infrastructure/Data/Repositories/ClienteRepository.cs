using KCIAO.API.Domain.Entities;
using KCIAO.API.Domain.Interfaces;
using KCIAO.API.Infrastructure.Data.AppData;

namespace KCIAO.API.Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationContext _context;

        public ClienteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ClienteEntity? DeletarDados(string id)
        {
            try
            {
                var cliente = _context.Cliente.Find(id);

                if (cliente is not null)
                {
                    _context.Remove(cliente);
                    _context.SaveChanges();

                    return cliente;
                }
                throw new Exception("Não foi possível localizar o cliente ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ClienteEntity? EditarDados(ClienteEntity entity)
        {
            try
            {
                var cliente = _context.Cliente.Find(entity.id_cliente);

                if (cliente is not null)
                {
                    cliente.nm_cliente = entity.nm_cliente;

                    _context.Update(cliente);
                    _context.SaveChanges();

                    return cliente;
                }

                throw new Exception("Não foi possível localizar o cliente ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public ClienteEntity? ObterporId(string id)
        {
            var cliente = _context.Cliente.Find(id);

            if (cliente is not null)
            {
                return cliente;
            }
            return null;
        }

        public IEnumerable<ClienteEntity>? ObterTodos()
        {
            var clientes = _context.Cliente.ToList();

            if (clientes.Any())
                return clientes;

            return null;
        }

        public ClienteEntity? SalvarDados(ClienteEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o cliente ");
            }
        }
    }
}
