using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.MVC.Application.Dtos
{
    public class ClienteDto
    {
        [Required(ErrorMessage = $"Campo {nameof(nm_cliente)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string nm_cliente { get; set; } = string.Empty;
    }
}
