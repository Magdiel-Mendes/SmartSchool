using System.Threading.Tasks;
using System.Collections.Generic;
using SmartSchool.API.Models;
using SmartSchool.API.Helpers;

namespace SmartSchool.API.Data
{
        public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();

         // Alunos
         Task<PageList<Aluno>>  GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
         Aluno[] GetAllAlunos(bool includeProfessor = false);
         Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
         Aluno GetAlunoById(int id, bool includeProfessor = false);
         // Professores
         Professor[] GetAllProfessores(bool includeAlunos = false);
         Professor[] GetAllProfessoressByDisciplinaId(int disciplinaId, bool includeAlunos = false);
         Professor GetProfessorById(int professorId, bool includeAlunos);

        
    }
}