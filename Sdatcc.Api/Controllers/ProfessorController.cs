using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Sdatcc.Api.Entidade;
using Sdatcc.Api.Dto;
using Sdatcc.Api.DataBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sdatcc.Api.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        // private BancoDados _bd;
        private DataContext _myDbContext;

        public ProfessorController(DataContext myDbContext)
        {
            //  _bd = bd;
            _myDbContext = myDbContext;
        }
        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _myDbContext.Professores;
            return Ok(dados);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{Cpf}")]
        public IActionResult BuscarProfessorId(string Cpf)
        {
            var professor = _myDbContext.Professores.FirstOrDefault(c => c.Cpf == Cpf);

            if (professor == null)
            {
                return NotFound();
            }


            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public async Task<IActionResult> CadastrarProfessor([FromBody] Professor value)
        {
            Professor professorEntity = new Professor();
            professorEntity.Nome = value.Nome;
            professorEntity.DataNascimento = value.DataNascimento;
            professorEntity.Cpf = Regex.Replace(value.Cpf, "[^0-9]", "");
            professorEntity.Email = value.Email;
            professorEntity.Senha = value.Senha;

            _myDbContext.Professores.Add(professorEntity);
            await _myDbContext.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{Cpf}")]
        public IActionResult AtualizarProfessor(string Cpf, [FromBody] Professorv2Dto value)
        {
            var professor = _myDbContext.Professores.FirstOrDefault(c => c.Cpf == Cpf);

            if (professor == null)
            {
                return BadRequest();
            }

            professor.Nome = value.Nome;
            professor.Email = value.Email;

            return Ok();
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult ExcluirProfessor(int Id)
        {
            var professor = _myDbContext.Professores.FirstOrDefault(c => c.Id == Id);

            if (professor == null)
            {
                return NotFound();
            }

            _myDbContext.Professores.Remove(professor);

            return NoContent();
        }
    }
}
