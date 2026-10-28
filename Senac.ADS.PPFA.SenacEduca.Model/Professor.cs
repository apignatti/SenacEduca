using System;
using System.Collections.Generic;
using System.Text;

namespace Senac.ADS.PPFA.SenacEduca.Model
{
    public class Professor : BaseModel
    {
        public string? Nome { get; set; }
        public string? Formacao { get; set; }
        public string? CPF { get; set; }

        public virtual ICollection<Grade>? Grades { get; set; } 
    }
}
