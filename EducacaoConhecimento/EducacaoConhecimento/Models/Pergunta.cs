using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducacaoConhecimento.Models
{
    [Table("Pergunta")]
    public class Pergunta
    {
        [ScaffoldColumn(false), Display(Name = "Código"), Editable(false)]
        public int PerguntaId { get; set; }
        [Display(Name = "Pergunta"), DataType(DataType.MultilineText), Required(ErrorMessage = "Campo obrigatório"), MaxLength(400)]
        public string Descricao { get; set; }
         [Display(Name = "Matéria"), Required(ErrorMessage = "Campo Obrigatório")]
        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }
         [Display(Name = "Dificuldade")]
        public Dificuldade Dificuldade { get; set; }

        public List<Resposta> respostas { get; set; }


        public static Pergunta MockPergunta()
        {
            var pergunta = new Pergunta();
            pergunta.PerguntaId = 1;
            pergunta.Descricao = "Quem descobriu o Brasil?";
            pergunta.Dificuldade = Dificuldade.Facil;

            pergunta.MateriaId = 1;

            pergunta.Materia = new Materia()
            {
                MateriaId = 1,
                Nome = "História"
            };

            pergunta.respostas = new List<Resposta>();

            var resposta1 = new Resposta();
            resposta1.Correta = true;
            resposta1.Descricao = "Resposta 1";
            resposta1.RespostaId = 1;
            pergunta.respostas.Add(resposta1);

            var resposta2 = new Resposta();
            resposta2.Correta = false;
            resposta2.Descricao = "Resposta 2";
            resposta2.RespostaId = 2;
            pergunta.respostas.Add(resposta2);

            var resposta3 = new Resposta();
            resposta3.Correta = false;
            resposta3.Descricao = "Resposta 3";
            resposta3.RespostaId = 3;
            pergunta.respostas.Add(resposta3);

            var resposta4 = new Resposta();
            resposta4.Correta = false;
            resposta4.Descricao = "Resposta 4";
            resposta4.RespostaId = 4;
            pergunta.respostas.Add(resposta4);

            return pergunta;
        }
    }
}