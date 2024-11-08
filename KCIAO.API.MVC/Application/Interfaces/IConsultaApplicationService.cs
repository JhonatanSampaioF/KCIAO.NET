using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Application.Dtos;

namespace KCIAO.API.MVC.Application.Interfaces
{
    public interface IConsultaApplicationService
    {
        IEnumerable<ConsultaEntity>? ObterTodasConsultas();
        ConsultaEntity? ObterConsultaporId(string id);
        ConsultaEntity? SalvarDadosConsulta(ConsultaDto entity);
        ConsultaEntity? EditarDadosConsulta(string id, ConsultaDto entity);
        ConsultaEntity? DeletarDadosConsulta(string id);
    }
}
