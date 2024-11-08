﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KCIAO.API.MVC.Models
{
    [Table("tb_evento")]
    public class EventoModel
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
        public DateOnly dt_evento { get; set; }
    }
}