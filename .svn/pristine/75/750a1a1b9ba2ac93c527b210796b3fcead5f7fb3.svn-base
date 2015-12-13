using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducacaoConhecimento.Models
{
    [Table("NivelUsuario")]
    public class NivelUsuario
    {
        [ScaffoldColumn(false), Display(Name = "Código"), Editable(false)]
        public int NivelUsuarioId { get; set; }
        [Display(Name = "Nível"), Required(ErrorMessage = "Campo obrigatório"), MaxLength(100)]
        public string Nome { get; set; }
        [Display(Name = "Pontuação Inicial")]
        public int PontuacaoInicial { get; set; }
        [Display(Name = "Pontuação Final")]
        public int PontuacaoFinal { get; set; }
        [Display(Name = "Peso")]
        public int Peso { get; set; }
    }
}