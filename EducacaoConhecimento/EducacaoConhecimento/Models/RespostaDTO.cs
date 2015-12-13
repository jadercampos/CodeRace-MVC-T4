using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducacaoConhecimento.Models
{
    public class RespostaDTO
    {        
        public int RespostaId { get; set; }
        
        public string Descricao { get; set; }
        
        public bool Correta { get; set; }
    }
}