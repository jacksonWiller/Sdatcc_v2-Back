using Microsoft.EntityFrameworkCore;
using Sdatcc.Api.Entidade;

namespace Sdatcc.Api.DataBase
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Arquivo> Arquivos { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Tcc> Tccs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

  }
}
