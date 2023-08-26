using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sdatcc.Api.Entidade;
using System.Data;

namespace Sdatcc.Api.DataBase
{
  public class DataContext : IdentityDbContext<Usuario, RegraUsuario, Guid>
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Arquivo> Arquivos { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Tcc> Tccs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
      modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(x => new { x.UserId, x.RoleId });
      modelBuilder.Entity<IdentityUserToken<Guid>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
    }

  }
}
