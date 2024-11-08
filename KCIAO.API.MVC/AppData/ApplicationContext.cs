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
        public DbSet<ClienteDoenca> ClienteDoenca { get; set; }
        public DbSet<ConsultaModel> Consulta { get; set; }
        public DbSet<EventoModel> Evento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the many-to-many relationship
            modelBuilder.Entity<ClienteDoenca>()
                .HasKey(cd => new { cd.fk_cliente, cd.fk_doenca });

            modelBuilder.Entity<ClienteDoenca>()
                .HasOne(cd => cd.Cliente)
                .WithMany(c => c.ClienteDoencas)
                .HasForeignKey(cd => cd.fk_cliente);

            modelBuilder.Entity<ClienteDoenca>()
                .HasOne(cd => cd.Doenca)
                .WithMany(d => d.ClienteDoencas)
                .HasForeignKey(cd => cd.fk_doenca);

            modelBuilder.Entity<EventoModel>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.Eventos)
                .HasForeignKey(e => e.fk_cliente);

            modelBuilder.Entity<EventoModel>()
                .HasOne(e => e.Consulta)
                .WithOne(c => c.Evento)
                .HasForeignKey<ConsultaModel>(c => c.fk_evento);
        }
    }
}
