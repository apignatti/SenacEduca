using System;
using System.Collections.Generic;
using System.Text;

namespace Senac.ADS.PPFA.SenacEduca.Model
{
    public class Grade : BaseModel
    {
        public int? TurmaId { get; set; }
        public int? DisciplinaId { get; set; }
        public int? ProfessorId { get; set; }
        public virtual Turma? Turma { get; set; }
        public virtual Disciplina? Disciplina { get; set; }
        public virtual Professor? Professor { get; set; }


    }
}
