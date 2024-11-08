using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KCIAO.API.MVC.Models
{
    [Table("tb_doenca")]
    public class DoencaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public string? id_doenca { get; set; }
        [DisplayName("Nome")]
        public string? nm_doenca { get; set; }
        public ICollection<ClienteDoenca> ClienteDoencas { get; set; } = new List<ClienteDoenca>();

    }
}