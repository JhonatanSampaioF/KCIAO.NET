using KCIAO.API.MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KCIAO.API.MVC.Domain.Entities
{
    [Table("tb_evento")]
    public class EventoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public string? id_evento { get; set; }
        [DisplayName("Tipo")]
        public string? tipo_evento { get; set; }
        [DisplayName("Descrição")]
        public string? desc_evento { get; set; }
        [DisplayName("Data")]
        public DateTime dt_evento { get; set; }
        [ForeignKey("Cliente")]
        [DisplayName("Cliente")]
        public string fk_cliente { get; set; }

        public ClienteModel Cliente { get; set; }

        public ConsultaModel Consulta { get; set; }

    }
}
