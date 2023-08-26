using System.ComponentModel.DataAnnotations;

namespace Sdatcc.Api.Entidade
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NumeroMatricula { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }

    }
}
