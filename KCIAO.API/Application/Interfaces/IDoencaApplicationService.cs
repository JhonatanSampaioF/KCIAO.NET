using KCIAO.API.Application.Dtos;
using KCIAO.API.Domain.Entities;

namespace KCIAO.API.Application.Interfaces
{
    public interface IDoencaApplicationService
    {
        IEnumerable<DoencaEntity>? ObterTodasDoencas();
        DoencaEntity? ObterDoencaporId(string id);
        DoencaEntity? SalvarDadosDoenca(DoencaDto entity);
        DoencaEntity? EditarDadosDoenca(string id, DoencaDto entity);
        DoencaEntity? DeletarDadosDoenca(string id);
    }
}
