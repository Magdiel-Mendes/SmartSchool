using System.Collections.Generic;
using System;

namespace SmartSchool.API.Models
{
    public class Aluno
    {
        // cetor sem parametro permite que eu crie um objeto sem parametro nenhum
        public Aluno() { }
        public Aluno(int id,
                     int matricula, 
                     string nome, 
                     string sobrenome, 
                     string telefone, 
                     DateTime dataNasc
                     )
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataNasc = dataNasc;
            this.Matricula = matricula;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas  { get; set; }

    }
}