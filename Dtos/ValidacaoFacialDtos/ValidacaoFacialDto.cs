namespace ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos
{
    public class ValidacaoFacialDto
    {
        public class CreateValidacaoDto
        {
          public Guid UsuarioId { get; set; }
          public string TipoValidacao { get; set; }
          public string? ResultadoValidacao { get; set; }
          public DateTime DataValidacao { get; set; } = DateTime.UtcNow;
          public bool Reconhecido { get; set; } = false;
          public string? ImagemPath { get; set; }
        }
    }
    public class ReadValidacaoDto
    {
        public Guid ValidacaoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string TipoValidacao { get; set; }
        public string ResultadoValidacao { get; set; }
        public string? ImagemPath { get; set; }
        public DateTime DataValidacao { get; set; }
        public bool Reconhecido { get; set; }
    }

    public class UpdateValidacaoDto
    {
        public Guid? ValidacaoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string TipoValidacao { get; set; }
        public string? ResultadoValidacao { get; set; }
        public DateTime DataValidacao { get; set; }
        public string ImagemPath { get; set; }
        public bool Reconhecido { get; set; }


    }


}

