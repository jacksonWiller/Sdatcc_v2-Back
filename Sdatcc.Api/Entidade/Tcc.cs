using System.ComponentModel.DataAnnotations;

namespace Sdatcc.Api.Entidade
{
    public class Tcc
    {
        [Key]
        public int Id { get; set; }
        public string Tema { get; set; }
        public DateTime DataPublicacao { get; set; }
        public DateTime DataEntregaTCC { get; set; }
        public string AreaEstudo { get; set; }
        public string Arquivo { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public virtual Professor Professor { get; set; }
        public int ProfessorId { get; set; }
    }
}
