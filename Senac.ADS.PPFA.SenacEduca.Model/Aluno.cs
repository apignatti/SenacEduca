namespace Senac.ADS.PPFA.SenacEduca.Model
{
    public class Aluno : BaseModel
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Telefone { get; set; }
        public int? TurmaId { get; set; }
        public virtual Turma? Turma { get; set; }


    }
}
