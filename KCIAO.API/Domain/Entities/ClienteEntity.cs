using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KCIAO.API.Domain.Entities
{
    [Table("tb_cliente")]
    public class ClienteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id_cliente { get; set; }
        public string nm_cliente { get; set; }
    }
}
