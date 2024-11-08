using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.MVC.Application.Dtos.Edits
{
    public class ConsultaEditDto
    {
        [Required(ErrorMessage = $"Campo {nameof(id_consulta)} é obrigatório")]
        public string? id_consulta { get; set; } = string.Empty;
        [Required(ErrorMessage = $"Campo {nameof(profissional)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string? profissional { get; set; } = string.Empty;
        [Required(ErrorMessage = $"Campo {nameof(local_consulta)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string? local_consulta { get; set; } = string.Empty;
        [Required(ErrorMessage = $"Campo {nameof(horario_consulta)} é obrigatório")]
        [RegularExpression(@"^([01][0-9]|2[0-3])[0-5][0-9]$", ErrorMessage = "Formato de horário inválido. Use o formato HHmm, por exemplo, 1630 para 16:30.")]
        public int horario_consulta { get; set; }
        [Required(ErrorMessage = $"Campo {nameof(fk_evento)} é obrigatório")]
        public string fk_evento { get; set; } = string.Empty;
    }
}
