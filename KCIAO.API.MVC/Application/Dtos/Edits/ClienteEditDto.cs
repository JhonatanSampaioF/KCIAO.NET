using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.MVC.Application.Dtos.Edits
{
    public class ClienteEditDto
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = $"Campo {nameof(id_cliente)} é obrigatório")]
        public string id_cliente { get; set; } = string.Empty;
        [DisplayName("Nome")]
        [Required(ErrorMessage = $"Campo {nameof(nm_cliente)} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres")]
        public string nm_cliente { get; set; } = string.Empty;
    }
}
