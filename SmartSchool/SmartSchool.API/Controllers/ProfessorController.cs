using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using System.Linq;
using SmartScool.API.Models;

namespace SmartScool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        public ProfessorController( IRepository repo ) 
        { 
            _repo = repo;
        }
            

        [HttpGet]
        public IActionResult Get()
        {
            var result =_repo.GetAllProfessores(true);
            return Ok(result);
        }

        // buscando aluno pelo Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetProfessorById(id, false);
            if (aluno == null) return BadRequest("O professor não foi encontrado");
            return Ok(aluno);
        }

        // Método simples para adicionar aluno
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
             _repo.Add(professor);
            if(_repo.SaveChanges())
            {
                return Ok("Professor cadastrado");
            }
            return BadRequest("Professor não cadastrado");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetAlunoById(id, false);
            if(prof == null) return BadRequest("Professor não encontrado");
            _repo.Update(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encontrado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
           var prof = _repo.GetAlunoById(id, false);
            if(prof == null) return BadRequest("Professor não encontrado");
            _repo.Update(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var prof = _repo.GetProfessorById(id, false);
            if(prof == null) return BadRequest("Aluno não encontrado");
            _repo.Delete(prof);
            if(_repo.SaveChanges())
            {
                return Ok("Professor deletado");
            }

            return BadRequest("Professor não deletado");
        }
    }
}
