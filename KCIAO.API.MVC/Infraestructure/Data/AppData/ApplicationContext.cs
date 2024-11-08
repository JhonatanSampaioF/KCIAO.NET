using KCIAO.API.MVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KCIAO.API.MVC.Infraestructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<DoencaEntity> Doenca { get; set; }
        public DbSet<ClienteDoenca> ClienteDoenca { get; set; }
        public DbSet<ConsultaEntity> Consulta { get; set; }
        public DbSet<EventoEntity> Evento { get; set; }

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

            modelBuilder.Entity<EventoEntity>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.Eventos)
                .HasForeignKey(e => e.fk_cliente);

            modelBuilder.Entity<EventoEntity>()
                .HasOne(e => e.Consulta)
                .WithOne(c => c.Evento)
                .HasForeignKey<ConsultaEntity>(c => c.fk_evento);
        }
    }
}
