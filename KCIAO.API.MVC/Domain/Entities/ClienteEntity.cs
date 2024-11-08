using KCIAO.API.MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KCIAO.API.MVC.Domain.Entities
{
    [Table("tb_cliente")]
    public class ClienteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public string? id_cliente { get; set; }
        [DisplayName("Nome")]
        public string? nm_cliente { get; set; }
        public ICollection<ClienteDoenca> ClienteDoencas { get; set; } = new List<ClienteDoenca>();

        public ICollection<EventoModel> Eventos { get; set; } = new List<EventoModel>();


    }
}
