using ReconhecimentoFacialApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("validacoes_faciais")]
public class ValidacaoFacial
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid Usuario_Id { get; set; }

    [ForeignKey("Usuario_Id")]
    public Usuario? Usuario { get; set; }

    public string Tipo_Validacao { get; set; } // "Facial" , "Cartão" , "Senha";

    public string Resultado_Validacao { get; set; }

    public string? Mensagem { get; set; }

    public string? Imagem_Path { get; set; }

    public DateTime Data_Validacao { get; set; } = DateTime.UtcNow;

    public string? Status { get; set; }

    public string? Dispositivo_Id { get; set; }

    public string? RawPayload { get; set; }
}
