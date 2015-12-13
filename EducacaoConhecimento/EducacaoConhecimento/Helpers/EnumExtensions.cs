using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EducacaoConhecimento.Helpers
{    
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            string descricao = attributes.Length > 0 ? attributes[0].Description : value.ToString();
            return descricao;
        }
    }    
}