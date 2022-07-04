using System.Collections.Generic;

namespace SmartScool.API.Models
{
    public class Aluno
    {
        // cetor sem parametro permite que eu crie um objeto sem parametro nenhum
        public Aluno() { }
        public Aluno(int id, string nome, string sobrenome, string telefone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas  { get; set; }

    }
}