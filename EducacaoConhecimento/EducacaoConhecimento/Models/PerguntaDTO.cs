using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducacaoConhecimento.Models
{
    public class PerguntaDTO
    {

        public int PerguntaId { get; set; }
        
        public string Descricao { get; set; }
        
        public int MateriaId { get; set; }

        public string MateriaDescricao { get; set; }

        public string Dificuldade { get; set; }

        public List<RespostaDTO> respostas;
    }    
}