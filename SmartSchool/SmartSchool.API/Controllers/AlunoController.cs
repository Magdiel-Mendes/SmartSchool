using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using SmartScool.API.Models;
using SmartSchool.API.Data;

namespace SmartScool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo) { 
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllAlunos(true));
        }

        // buscando aluno pelo Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        // Método simples para adicionar aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Ok("Aluno cadastrado");
            }
            return BadRequest("Aluno não cadastrado");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var alu = _repo.GetAlunoById(id);
            if(alu == null) return BadRequest("Aluno não encontrado");
           _repo.Delete(alu);
            if(_repo.SaveChanges())
            {
                return Ok("Aluno Deletado");
            }
            return BadRequest("Aluno não Deletado");
        }
    }
}