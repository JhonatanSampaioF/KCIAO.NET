using KCIAO.API.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace KCIAO.API.MVC.AppData
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<DoencaModel> Doenca { get; set; }
        public DbSet<ConsultaModel> Consulta { get; set; }
        public DbSet<EventoModel> Evento { get; set; }
    }
}
