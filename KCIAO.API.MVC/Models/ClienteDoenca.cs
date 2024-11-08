using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KCIAO.API.MVC.Models
{
    [Table("tb_cliente_doenca")]
    public class ClienteDoenca
    {
        [DisplayName("Cliente")]
        public string fk_cliente { get; set; }
        public ClienteModel Cliente { get; set; }

        [DisplayName("Doença")]
        public string fk_doenca { get; set; }
        public DoencaModel Doenca { get; set; }
    }
}
