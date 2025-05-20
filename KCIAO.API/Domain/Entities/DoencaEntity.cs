using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.Domain.Entities
{
    [Table("tb_doenca")]
    public class DoencaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? id_doenca { get; set; }
        public string? nm_doenca { get; set; }
    }
}
