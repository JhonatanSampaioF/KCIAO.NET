using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Domain.Interfaces;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Application.Services
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

        public DoencaEntity? EditarDadosDoenca(string id, DoencaEditDto entity)
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
