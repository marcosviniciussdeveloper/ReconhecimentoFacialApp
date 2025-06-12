using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReconhecimentoFacialApp.Models;

[Table("usuarios")]
public class Usuario
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Nome { get; set; }
    [Required]
    public string Cpf { get; set; }

    public string? Img_Codigo { get; set; }
    [Required]
    public string Email { get; set; }

    public DateTime Created_At { get; set; }

    public string? Tipo_Usuario { get; set; }
}
