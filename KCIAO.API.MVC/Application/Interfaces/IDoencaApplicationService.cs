using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Application.Interfaces
{
    public interface IDoencaApplicationService
    {
        IEnumerable<DoencaEntity>? ObterTodasDoencas();
        DoencaEntity? ObterDoencaporId(string id);
        DoencaEntity? SalvarDadosDoenca(DoencaDto entity);
        DoencaEntity? EditarDadosDoenca(string id, DoencaEditDto entity);
        DoencaEntity? DeletarDadosDoenca(string id);
    }
}
