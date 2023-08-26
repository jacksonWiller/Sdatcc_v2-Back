using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sdatcc.Api.Dto;
using Sdatcc.Api.Dto.User.AccountDto;
using Sdatcc.Api.Entidade;

namespace Sdatcc.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContaController : Controller
  {

    // private readonly IConfiguration _config;
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    // private readonly IMapper _mapper;

    public ContaController(
                          // IConfiguration config,
                          UserManager<Usuario> userManager,
                          SignInManager<Usuario> signInManager
                        //   IMapper mapper
                        )
    {
      _signInManager = signInManager;
      //   _mapper = mapper;
      //   _config = config;
      _userManager = userManager;
    }

    [HttpGet("GetUser")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUser()
    {
      return Ok(new RegisterDto());
    }

    [HttpGet("GetUserSingIn")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserSingIn()
    {
      return Ok(_userManager.GetUserAsync(User));
    }

    [HttpPost("Logout")]
    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return Ok("Deslogado");
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromForm] RegisterDto model)
    {
      try
      {
        var user = new Usuario
        {
          UserName = model.Email,
          Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          return Created("GetUser", user);
        }

        return BadRequest(result.Errors);
      }
      catch (System.Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
      }
    }

    [HttpPost("Login")]
    [AllowAnonymous]

    public async Task<IActionResult> Login([FromForm] LoginViewModel model)
    {
      try
      {

        if (ModelState.IsValid)
        {
          var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

          if (result.Succeeded)
          {
            return Ok("Ok");
          }
          else
          {
            ModelState.AddModelError(string.Empty, "Tentativa de login inválida");
          }
        }

        return View(model);
      }
      catch (System.Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
      }

    }

  }
}
