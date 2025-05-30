﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.MVC.Application.Dtos
{
    public class ConsultaDto
    {

        [DisplayName("Profissional")]
        [Required(ErrorMessage = $"Campo {nameof(profissional)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string? profissional { get; set; } = string.Empty;

        [DisplayName("Local")]
        [Required(ErrorMessage = $"Campo {nameof(local_consulta)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string? local_consulta { get; set; } = string.Empty;

        [DisplayName("Horário")]
        [Required(ErrorMessage = $"Campo {nameof(horario_consulta)} é obrigatório")]
        [RegularExpression(@"^([01][0-9]|2[0-3])[0-5][0-9]$", ErrorMessage = "Formato de horário inválido. Use o formato HHmm, por exemplo, 1630 para 16:30.")]
        public int horario_consulta { get; set; }

        [DisplayName("Id Evento")]
        [Required(ErrorMessage = $"Campo {nameof(fk_evento)} é obrigatório")]
        public string fk_evento { get; set; } = string.Empty;
    }
}
