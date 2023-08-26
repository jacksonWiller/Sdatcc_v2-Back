using Microsoft.AspNetCore.Mvc;
using Sdatcc.Api.DataBase;
using Sdatcc.Api.Dto;
using Sdatcc.Api.Entidade;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sdatcc.Api.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class TccController : ControllerBase
    {
        //private BancoDados _bd;
        private DataContext _myDbContext;

        public TccController(DataContext myDbContext)
        {
            // _bd = bd;
            _myDbContext = myDbContext;
        }
        // GET: api/<TccController>
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _myDbContext.Tccs;

            return Ok(dados);
        }

        // GET api/<TccController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TccController>
        [HttpPost]
        public IActionResult CadastrarTcc([FromBody] TccDto value)
        {
            var professor = _myDbContext.Professores.FirstOrDefault(c => c.Cpf == value.ProfessorCpf);

            if (professor == null)
            {
                return NotFound();
            }

            var aluno = _myDbContext.Alunos.FirstOrDefault(c => c.Cpf == value.AlunoCpf);

            if (aluno == null)
            {
                return NotFound();
            }


            Tcc tccEntity = new Tcc();
            tccEntity.Tema = value.Tema;
            tccEntity.AreaEstudo = value.AreaEstudo;
            tccEntity.DataPublicacao = value.DataPublicacao;
            tccEntity.DataEntregaTCC = value.DataEntregaTCC;
            tccEntity.AlunoId = aluno.Id;
            tccEntity.ProfessorId = professor.Id;

            _myDbContext.Tccs.Add(tccEntity);

            return Ok();
        }

        // PUT api/<TccController>/5
        [HttpPut("{Id}")]
        public IActionResult AtualizarTCC(int Id, [FromBody] Tccv2Dto value)
        {
            var tcc = _myDbContext.Tccs.FirstOrDefault(c => c.Id == Id);

            if (tcc == null)
            {
                return BadRequest();
            }

            tcc.AreaEstudo = value.AreaEstudo;

            return Ok();
        }

        // DELETE api/<TccController>/5
        [HttpDelete("{id}")]
        public IActionResult ExcluirTcc(int Id)
        {
            var tcc = _myDbContext.Tccs.FirstOrDefault(c => c.Id == Id);
            if (tcc == null)
            {
                return NotFound();
            }

            _myDbContext.Tccs.Remove(tcc);
            return NoContent();
        }
    }
}
