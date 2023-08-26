using System;
using System.Collections.Generic;
using System.Text;

namespace Sdatcc.Api.Dto
{
    public class TccDto
    {
        public string Tema { get; set; }
        public DateTime DataPublicacao { get; set; }
        public DateTime DataEntregaTCC { get; set; }
        public string AreaEstudo { get; set; }
        public string ProfessorCpf { get; set; }
        public string AlunoCpf { get; set; }
        public string Arquivo { get; set; }
    }
}
