using System.ComponentModel.DataAnnotations;

namespace Sdatcc.Api.Entidade
{
    public class Arquivo
    {
        [Key]
        public int Id { get; set; }
        public string CaminhoArquivo { get; set; }
        public string NomeOriginal { get; set; }
        public string GuidArquivo { get; set; }
    }
}
