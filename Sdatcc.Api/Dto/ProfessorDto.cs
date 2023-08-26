using System;
using System.Collections.Generic;
using System.Text;

namespace Sdatcc.Api.Dto
{
    public class ProfessorDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
    }
}
