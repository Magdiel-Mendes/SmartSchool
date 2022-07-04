using System.Collections.Generic;

namespace SmartScool.API.Models
{
    public class Disciplina
    {
        Disciplina() { }
        public Disciplina(int id, string nome, int professorId)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }

        //Professor é do tipo professor ou seja é do mesmo tipo da classe
        public Professor Professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas  { get; set; }
    }
}