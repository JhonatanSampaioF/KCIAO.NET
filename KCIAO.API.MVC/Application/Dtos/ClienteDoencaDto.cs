using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.MVC.Application.Dtos
{
    public class ClienteDoencaDto
    {
        [Required(ErrorMessage = $"Campo {nameof(fk_cliente)} é obrigatório")]
        public string fk_cliente { get; set; } = string.Empty;
        [Required(ErrorMessage = $"Campo {nameof(fk_doenca)} é obrigatório")]
        public string fk_doenca { get; set; } = string.Empty;
    }
}
