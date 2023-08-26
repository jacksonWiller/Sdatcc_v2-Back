using Microsoft.AspNetCore.Mvc;
using Sdatcc.Api.DataBase;
using Sdatcc.Api.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sdatcc.Api.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private DataContext _myDbContext;

        public AlunoController(DataContext myDbContext)
        {

            _myDbContext = myDbContext;

        }
        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _myDbContext.Alunos.ToList();

            return Ok(dados);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{Cpf}")]
        public IActionResult BuscarAlunoCpf(string Cpf)
        {
            var aluno = _myDbContext.Alunos.FirstOrDefault(c => c.Cpf == Cpf);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // POST api/<AlunoController>
        //[HttpPost]
        //public async Task<IActionResult> CadastrarAluno([FromBody] Aluno value)
        //{

        //    Aluno alunoEntity = new Aluno();
        //    alunoEntity.Nome = value.Nome;
        //    var testNomeVazio = Regex.Replace(alunoEntity.Nome, @"\s+", "");
        //    if (testNomeVazio == string.Empty)
        //    {
        //        return StatusCode(500);
        //    }
        //    bool hasNumber = value.Nome.Any(char.IsDigit);
        //    if (hasNumber)
        //    {
        //        Console.WriteLine("Nome inválido");
        //        return StatusCode(500);
        //    }

        //    alunoEntity.Email = value.Email;
        //    alunoEntity.DataNascimento = value.DataNascimento;
        //    alunoEntity.NumeroMatricula = value.NumeroMatricula;
        //    alunoEntity.Senha = value.Senha;
        //    value.Senha = BCrypt.Net.BCrypt.HashPassword(value.Senha);
        //    _myDbContext.Alunos.Add(alunoEntity);
        //    await _myDbContext.SaveChangesAsync();

        //    return Ok();

        //}


        // PUT api/<AlunoController>/5
        [HttpPut("{Cpf}")]
        public IActionResult AtualizarAluno(string Cpf, [FromBody] Alunov2Dto value)
        {
            var aluno = _myDbContext.Alunos.FirstOrDefault(c => c.Cpf == Cpf);
            if (aluno == null)
            {
                return BadRequest();
            }

            aluno.Nome = value.Nome;
            aluno.Email = value.Email;

            return Ok();
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{Id}")]
        public IActionResult ExcluirAluno(int Id)
        {
            var aluno = _myDbContext.Alunos.FirstOrDefault(c => c.Id == Id);

            if (aluno == null)
            {
                return NotFound();
            }

            _myDbContext.Alunos.Remove(aluno);

            return NoContent();
        }
    }
}
