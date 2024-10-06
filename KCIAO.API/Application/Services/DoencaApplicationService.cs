using KCIAO.API.Application.Dtos;
using KCIAO.API.Application.Interfaces;
using KCIAO.API.Domain.Entities;
using KCIAO.API.Domain.Interfaces;

namespace KCIAO.API.Application.Services
{
    public class DoencaApplicationService : IDoencaApplicationService
    {
        private readonly IDoencaRepository _doencaRepository;

        public DoencaApplicationService(IDoencaRepository doencaRepository)
        {
            _doencaRepository = doencaRepository;
        }

        public DoencaEntity? DeletarDadosDoenca(string id)
        {
            return _doencaRepository.DeletarDados(id);
        }

        public DoencaEntity? EditarDadosDoenca(string id, DoencaDto entity)
        {
            var doenca = new DoencaEntity
            {
                id_doenca = id,
                nm_doenca = entity.nm_doenca
            };

            return _doencaRepository.EditarDados(doenca);
        }

        public DoencaEntity? ObterDoencaporId(string id)
        {
            return _doencaRepository.ObterporId(id);
        }

        public IEnumerable<DoencaEntity>? ObterTodasDoencas()
        {
            return _doencaRepository.ObterTodos();
        }

        public DoencaEntity? SalvarDadosDoenca(DoencaDto entity)
        {
            var doenca = new DoencaEntity
            {
                nm_doenca = entity.nm_doenca
            };

            return _doencaRepository.SalvarDados(doenca);
        }
    }
}
