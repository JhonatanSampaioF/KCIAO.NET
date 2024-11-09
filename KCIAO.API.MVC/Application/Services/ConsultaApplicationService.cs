using KCIAO.API.MVC.Domain.Entities;
using KCIAO.API.MVC.Domain.Interfaces;
using KCIAO.API.MVC.Application.Interfaces;
using KCIAO.API.MVC.Application.Dtos;
using KCIAO.API.MVC.Application.Dtos.Edits;

namespace KCIAO.API.MVC.Application.Services
{
    public class ConsultaApplicationService : IConsultaApplicationService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaApplicationService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public ConsultaEntity? DeletarDadosConsulta(string id)
        {
            return _consultaRepository.DeletarDados(id);
        }

        public ConsultaEntity? EditarDadosConsulta(string id, ConsultaEditDto entity)
        {
            var consulta = new ConsultaEntity
            {
                id_consulta = id,
                profissional = entity.profissional,
                local_consulta = entity.local_consulta,
                horario_consulta = entity.horario_consulta,
                fk_evento = entity.fk_evento
            };

            return _consultaRepository.EditarDados(consulta);
        }

        public ConsultaEntity? ObterConsultaporId(string id)
        {
            return _consultaRepository.ObterporId(id);
        }

        public IEnumerable<ConsultaEntity>? ObterTodasConsultas()
        {
            return _consultaRepository.ObterTodos();
        }

        public ConsultaEntity? SalvarDadosConsulta(ConsultaDto entity)
        {
            var consulta = new ConsultaEntity
            {
                profissional = entity.profissional,
                local_consulta = entity.local_consulta,
                horario_consulta = entity.horario_consulta,
                fk_evento = entity.fk_evento
            };

            return _consultaRepository.SalvarDados(consulta);
        }
    }
}
