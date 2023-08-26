using Microsoft.EntityFrameworkCore;
using Sdatcc.Api.DataBase;

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

      services.AddControllers();
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
