﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducacaoConhecimento.Models
{
    [Table("Profile")]
    public class Profile
    {
        [Key]
        [Display(Name = "Código do Usuário"), Required(ErrorMessage = "Campo obrigatório"), MaxLength(100)]
        public string CodUsuario { get; set; }
        [Display(Name = "Pontuação")]
        public int Pontuacao { get; set; }
        [Display(Name = "Avatar"), MaxLength(100)]
        public string Avatar { get; set; }
        [Display(Name = "Nível do Usuário"), Required(ErrorMessage = "Campo Obrigatório")]
        public int NivelUsuarioId { get; set; }
        public virtual NivelUsuario NivelUsuario { get; set; }
    }
}