using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducacaoConhecimento.Models
{
    [Table("Resposta")]
    public class Resposta
    {
        [ScaffoldColumn(false), Display(Name = "Código"), Editable(false)]
        public int RespostaId { get; set; }
        [Display(Name = "Pergunta"), Required(ErrorMessage = "Campo Obrigatório")]
        public int PerguntaId { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        [Display(Name = "Resposta"), DataType(DataType.MultilineText), Required(ErrorMessage = "Campo obrigatório"), MaxLength(400)]
        public string Descricao { get; set; }
        [Display(Name = "Correta")]
        public bool Correta { get; set; }

    }
}