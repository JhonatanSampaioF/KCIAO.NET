using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KCIAO.API.Domain.Entities
{
    [Table("tb_evento")]
    public class EventoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? id_evento { get; set; }
        public string? tipo_evento { get; set; }
        public string? desc_evento { get; set; }
        public DateTime dt_evento { get; set; }
    }
}
