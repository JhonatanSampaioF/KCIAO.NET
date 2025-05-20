using Microsoft.EntityFrameworkCore;
using Xunit;
using KCIAO.API.Infrastructure.Data.AppData;
using KCIAO.API.Infrastructure.Data.Repositories;
using KCIAO.API.Domain.Entities;
using System.Linq;

namespace KCIAO.API.Tests.Repositories
{
    public class DoencaRepositoryTests
    {
        private readonly ApplicationContext _context;
        private readonly DoencaRepository _repository;

        public DoencaRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ApplicationContext(options);
            _repository = new DoencaRepository(_context);
        }

        [Fact]
        public void SalvarDados_DeveAdicionarDoenca()
        {
            var doenca = new DoencaEntity { id_doenca = "1", nm_doenca = "Gengivite" };

            _repository.SalvarDados(doenca);
            var doencas = _repository.ObterTodos();

            Assert.Contains(doencas, d => d.nm_doenca == "Gengivite");
        }
    }
}
