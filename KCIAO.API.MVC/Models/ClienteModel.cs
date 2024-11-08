using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KCIAO.API.MVC.Models
{
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public string id_cliente { get; set; }
        [DisplayName("Nome")]
        public string nm_cliente { get; set; }
    }
}
