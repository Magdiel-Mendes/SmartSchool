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
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context) { 
            _context = context;
        }
            

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // buscando aluno pelo Id
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            return Ok(professor);
        }

        // buscando o aluno pelo nome
        [HttpGet("{byName}")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(p =>  p.Nome.Contains(nome));
            if (professor == null) return BadRequest("O Professor não foi encontrado");
            return Ok(professor);
        }

        // Método simples para adicionar aluno
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Alunos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");
            _context.Update(prof);
            _context.SaveChanges();
            return Ok(prof);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Alunos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Aluno não encontrado");
            _context.Update(prof);
            _context.SaveChanges();
            return Ok(prof);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var professor = _context.Alunos.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest("Aluno não encontrado");
            _context.Remove(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
    }
}
/*using System.Collections.Generic;
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
        private readonly SmartContext _context;
        public AlunoController(SmartContext context) { 
            _context = context;
        }
            

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // buscando aluno pelo Id
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        // buscando o aluno pelo nome
        [HttpGet("{byName}")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a =>
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        // Método simples para adicionar aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno não encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
    }
}*/