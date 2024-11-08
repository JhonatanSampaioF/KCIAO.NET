using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KCIAO.API.MVC.Models
{
    [Table("tb_consulta")]
    public class ConsultaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public string? id_consulta { get; set; }
        [DisplayName("Profissional")]
        public string? profissional { get; set; }
        [DisplayName("Local")]
        public string? local_consulta { get; set; }
        [DisplayName("Horário")]
        public int horario_consulta { get; set; }
    }
}
