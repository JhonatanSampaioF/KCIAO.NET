﻿using KCIAO.API.MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KCIAO.API.MVC.Domain.Entities
{
    [Table("tb_consulta")]
    public class ConsultaEntity
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
        [ForeignKey("Evento")]
        [DisplayName("Evento")]
        public string fk_evento { get; set; }

        public EventoEntity Evento { get; set; }
    }
}
