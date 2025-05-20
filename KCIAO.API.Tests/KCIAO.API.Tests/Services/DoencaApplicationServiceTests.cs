using Xunit;
using Moq;
using KCIAO.API.Application.Services;
using KCIAO.API.Domain.Interfaces;
using KCIAO.API.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace KCIAO.API.Tests.Services
{
    public class DoencaApplicationServiceTests
    {
        private readonly DoencaApplicationService _service;
        private readonly Mock<IDoencaRepository> _repositoryMock;

        public DoencaApplicationServiceTests()
        {
            _repositoryMock = new Mock<IDoencaRepository>();
            _service = new DoencaApplicationService(_repositoryMock.Object);
        }

        [Fact]
        public void ObterTodasDoencas_DeveRetornarLista()
        {
            var doencasFake = new List<DoencaEntity>
            {
                new DoencaEntity { id_doenca = "1", nm_doenca = "Gengivite" },
                new DoencaEntity { id_doenca = "2", nm_doenca = "Cárie" }
            };
            _repositoryMock.Setup(r => r.ObterTodos()).Returns(doencasFake);

            var resultado = _service.ObterTodasDoencas();

            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
        }

        [Fact]
        public void ObterDoencaporId_DeveRetornarDoenca()
        {
            var doenca = new DoencaEntity { id_doenca = "1", nm_doenca = "Gengivite" };
            _repositoryMock.Setup(r => r.ObterporId("1")).Returns(doenca);

            var resultado = _service.ObterDoencaporId("1");

            Assert.NotNull(resultado);
            Assert.Equal("Gengivite", resultado.nm_doenca);
        }
    }
}
