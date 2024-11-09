using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.MVC.Application.Dtos
{
    public class DoencaDto
    {

        [DisplayName("Nome")]
        [Required(ErrorMessage = $"Campo {nameof(nm_doenca)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string nm_doenca { get; set; } = string.Empty;
    }
}
