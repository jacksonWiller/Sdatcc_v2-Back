using Microsoft.AspNetCore.Mvc;
using Sdatcc.Api.DataBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sdatcc.Api.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private DataContext _DataContext;
        public LoginController(DataContext DataContext)
        {

            _DataContext = DataContext;

        }
        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _DataContext.Logins;

            return Ok(dados);
        }

        // GET api/<LoginController>/5
        //[HttpGet("{id}")]
        //public IActionResult BuscarPorUsuario([FromBody] Login value)
        //{
        //    var user = _DataContext.Logins.FirstOrDefault(c => c.Cpf == value.Cpf && c.Senha == value.Senha);

        //    if (user == null || !BCrypt.Net.BCrypt.Verify(value.Senha, user.Senha))
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok();
        //}

    }
}
