using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.MVC.Application.Dtos
{
    public class EventoDto
    {

        [DisplayName("Tipo")]
        [Required(ErrorMessage = $"Campo {nameof(tipo_evento)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string? tipo_evento { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = $"Campo {nameof(desc_evento)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string? desc_evento { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = $"Campo {nameof(dt_evento)} é obrigatório")]
        public DateTime dt_evento { get; set; }

        [DisplayName("Id Cliente")]
        [Required(ErrorMessage = $"Campo {nameof(fk_cliente)} é obrigatório")]
        public string fk_cliente { get; set; }
    }
}
