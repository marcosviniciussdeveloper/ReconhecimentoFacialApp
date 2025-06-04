using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReconhecimentoFacialApp.Models
{
    [Table("validacoes_faciais")]
    public class ValidacaoFacial
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid Usuario_Id { get; set; }

        public string? Tipo_Validacao { get; set; }

        public string? Resultado_Validacao { get; set; }

        public string? Mensagem { get; set; }

        public string? Imagem_Path { get; set; }

        public DateTime Data_Validacao { get; set; } = DateTime.UtcNow;

        [ForeignKey("Usuario_Id")]
        public Usuario? Usuario { get; set; }
    }
}
