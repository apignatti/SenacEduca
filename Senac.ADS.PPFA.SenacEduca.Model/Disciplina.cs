using System;
using System.Collections.Generic;
using System.Text;

namespace Senac.ADS.PPFA.SenacEduca.Model
{
    public class Disciplina : BaseModel
    {
        public string? Descricao { get; set; }
        public string? CargaHoraia { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}
