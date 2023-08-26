using System.ComponentModel.DataAnnotations;

namespace Sdatcc.Api.Entidade
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
    }
}
