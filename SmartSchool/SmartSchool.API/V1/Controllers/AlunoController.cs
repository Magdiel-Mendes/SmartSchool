using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Threading.Tasks;
using SmartSchool.API.v1.Dtos;
using AutoMapper;
using SmartSchool.API.Helpers;

namespace SmartSchool.API.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
   
    public class AlunoController : ControllerBase
    {
        /// <summary>
        /// Versão 1.0 do meu controlador de alunos
        /// </summary>
        private readonly IRepository _repo;
        private readonly IMapper _Mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper) { 
            _repo = repo;
            _Mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var alunos = await _repo.GetAllAlunosAsync(pageParams, true);
            var alunosResult = _Mapper.Map<IEnumerable<AlunoDto>>(alunos);
            Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPage);
            return Ok(alunosResult);
        }
        
        [HttpGet("GetRegister")]
        public IActionResult GetRegister()
        {
          return Ok(new AlunoRegistrarDto());
        }
        /// <summary>
        /// buscando aluno pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Pega apenas um aluno
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            // Mapeia o aluno pelo alunoDto
            var alunoDto = _Mapper.Map<AlunoDto>(aluno);
            return Ok(alunoDto);
        }
        /// <summary>
        /// Método simples para adicionar aluno
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _Mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _Mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não cadastrado");
        }

        /// <summary>
        /// atualiza o aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            _Mapper.Map(model, aluno);
            
            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _Mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não atualizado");
        }   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            _Mapper.Map(model, aluno);
            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _Mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não atualizado");
        }
        /// <summary>
        /// deleta o aluno passando o Id COMO PARAMETRO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
           _repo.Delete(aluno);
            if(_repo.SaveChanges())
            {
                return Ok("Aluno Deletado");
            }
            return BadRequest("Aluno não Deletado");
        }
    }
}