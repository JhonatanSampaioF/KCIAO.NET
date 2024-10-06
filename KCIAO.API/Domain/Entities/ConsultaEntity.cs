using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KCIAO.API.Domain.Entities
{
    [Table("tb_consulta")]
    public class ConsultaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id_consulta { get; set; }
        public string profissional { get; set; }
        public string local_consulta { get; set; }
        public int horario_consulta { get; set; }
    }
}
