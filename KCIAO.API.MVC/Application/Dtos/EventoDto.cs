using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using KCIAO.API.MVC.Infraestructure.Converters;

namespace KCIAO.API.MVC.Application.Dtos
{
    public class EventoDto
    {
        [Required(ErrorMessage = $"Campo {nameof(tipo_evento)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string? tipo_evento { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(desc_evento)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string? desc_evento { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(dt_evento)} é obrigatório")]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime dt_evento { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(fk_cliente)} é obrigatório")]
        public string fk_cliente { get; set; }
    }
}
