using Microsoft.AspNetCore.Mvc;
using Sdatcc.Api.Entidade;
using Sdatcc.Api.DataBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sdatcc.Api.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private DataContext _myDbContext;

        /// <summary>
        /// Salvar o arquivo no caminho indicado no caminho indicado, caso ele não exista, ele será criado
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="myDbContext"></param>
        public ArquivoController(IConfiguration configuration, DataContext myDbContext)
        {
            _configuration = configuration;

            _myDbContext = myDbContext;


            if (!Directory.Exists("C:\\SdaTcc"))
            {
                Directory.CreateDirectory("C:\\SdaTcc");
            }


        }
        /// <summary>
        /// Realizar a busca de todos os TCCs
        /// </summary>
        /// <returns></returns>
        // GET: api/<ArquivoController>
        [HttpGet]
        public async Task<IActionResult> BuscarTccs()
        {
            var arq = _myDbContext.Arquivos.ToList();
            return Ok(arq);
        }

        /// <summary>
        /// Criar um guid para o arquivo
        /// </summary>
        /// <param name="GuidArquivo"></param>
        /// <returns></returns>

        // GET api/<ArquivoController>/5
        [HttpGet("{GuidArquivo}")]
        public IActionResult BuscarTccPorGuid(string GuidArquivo)
        {
            var arquivo = _myDbContext.Arquivos.FirstOrDefault(c => c.GuidArquivo == GuidArquivo);
            if (arquivo == null)
            {
                return NotFound();
            }

            return Ok(arquivo);
        }

        /// <summary>
        /// Carregar os Tccs em PDF
        /// </summary>
        /// <param name="arquivos"></param>
        /// <returns></returns>

        // POST api/<ArquivoController>
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm] ICollection<IFormFile> arquivos)
        {
            string[] permittedExtensions = { ".pdf" };

            Arquivo arquivoEntity = new Arquivo();


            string guid = Guid.NewGuid().ToString();
            arquivoEntity.GuidArquivo = guid;

            _myDbContext.Arquivos.Add(arquivoEntity);

            string caminhoDestinoArquivo = "C:\\SdaTcc\\";
            arquivoEntity.CaminhoArquivo = caminhoDestinoArquivo;

            foreach (var arquivo in arquivos)
            {
                var ext = Path.GetExtension(arquivo.FileName).ToLowerInvariant();

                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    return StatusCode(500);
                }
                string caminhoDestinoArquivoOriginal = caminhoDestinoArquivo + arquivo.FileName;
                using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
                {
                    arquivo.CopyTo(stream);
                }

                arquivoEntity.NomeOriginal = arquivo.FileName;


                await _myDbContext.SaveChangesAsync();
            }

            return Ok(guid);
        }

        /// <summary>
        /// Baixar o arquivo
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("Download")]

        public IActionResult DownloadArquivo(string guid)
        {
            var arquivo = _myDbContext.Arquivos.FirstOrDefault(c => c.GuidArquivo == guid);

            string filePath = arquivo.CaminhoArquivo;
            string fileName = arquivo.NomeOriginal;

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath + fileName);

            return File(fileBytes, "application/force-download", fileName);
        }

        /// <summary>
        /// Deleta um arquivo cadastrado
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// /
        [HttpDelete("Delete/{fileName}")]
        public IActionResult Delete(string fileName)
        {
            try
            {

                Arquivo arquivoToDelete = _myDbContext.Arquivos.FirstOrDefault(a => a.NomeOriginal == fileName);

                if (arquivoToDelete == null)
                {
                    return NotFound();
                }

                string caminhoDestinoArquivoOriginal = Path.Combine(arquivoToDelete.CaminhoArquivo, arquivoToDelete.NomeOriginal);
                if (System.IO.File.Exists(caminhoDestinoArquivoOriginal))
                {
                    System.IO.File.Delete(caminhoDestinoArquivoOriginal);
                }

                _myDbContext.Arquivos.Remove(arquivoToDelete);
                _myDbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

