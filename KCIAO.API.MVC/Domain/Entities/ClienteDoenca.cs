using KCIAO.API.MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace KCIAO.API.MVC.Domain.Entities
{
    [Table("tb_cliente_doenca")]
    public class ClienteDoenca
    {
        [DisplayName("Cliente")]
        public string fk_cliente { get; set; }
        public ClienteEntity Cliente { get; set; }

        [DisplayName("Doença")]
        public string fk_doenca { get; set; }
        public DoencaEntity Doenca { get; set; }
    }
}
