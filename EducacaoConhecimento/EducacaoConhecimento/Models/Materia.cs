using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducacaoConhecimento.Models
{
    [Table("Materia")]
    public class Materia
    {
        [ScaffoldColumn(false), Display(Name = "Código"), Editable(false)]
        public int MateriaId { get; set; }
        [Display(Name = "Matéria"), Required(ErrorMessage = "Campo obrigatório"), MaxLength(100)]
        public string Nome { get; set; }
    }
}