using KCIAO.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KCIAO.API.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext

    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<DoencaEntity> Doenca { get; set; }
        public DbSet<ClienteEntity> Cliente { get; set; }
    }
}
