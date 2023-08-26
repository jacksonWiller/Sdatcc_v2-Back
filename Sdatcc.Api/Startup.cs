using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Sdatcc.Api.DataBase;
using Sdatcc.Api.Entidade;
using System.Data;

namespace Sdatcc.Api
{
  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigurationService(IServiceCollection services)
    {

      services.AddDbContext<DataContext>(
        context => context.UseSqlite(Configuration.GetConnectionString("SqliteDatabase"))
      );

      //services.AddDbContext<DataContext>(
      //  context => context.UseSqlServer(Configuration.GetConnectionString("SqlServerDatabase"))
      //);

      services.AddIdentity<Usuario, RegraUsuario>(options => {
        //Lockout
        // options.Lockout.AllowedForNewUsers = true;
        // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        // options.Lockout.MaxFailedAccessAttempts = 5;

        //Password
        // options.Password.RequireDigit = true;
        // options.Password.RequiredLength = 6;
        // options.Password.RequiredUniqueChars = 1;
        // options.Password.RequireLowercase = true;
        // options.Password.RequireUppercase = true;
        // options.Password.RequireNonAlphanumeric = true;

        //SignIn
        // options.SignIn.RequireConfirmedEmail = false;
        // options.SignIn.RequireConfirmedPhoneNumber = false;

        //Token
        //options.Tokens.AuthenticatorTokenProvider
        //options.Tokens.ChangeEmailTokenProvider
        //options.Tokens.ChangePhoneNumberTokenProvider
        //options.Tokens.EmailConfirmationTokenProvider
        //options.Tokens.PasswordResetTokenProvider

        //User
        // options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        // options.User.RequireUniqueEmail = false;
      })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

      services.ConfigureApplicationCookie(option => {
        option.Cookie.HttpOnly = true;
        option.ExpireTimeSpan = TimeSpan.FromMinutes(5);

      });

      services.AddControllers(config => {
        var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
      }).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                  Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();

    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();

      app.MapControllers();
    }
  }
}
