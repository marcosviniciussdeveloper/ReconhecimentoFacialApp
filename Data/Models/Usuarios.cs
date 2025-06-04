using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReconhecimentoFacialApp.Models;

[Table("usuarios")]
public class Usuario
{
    [Key]
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Cpf { get; set; }

    public string? Img_Codigo { get; set; }

    public DateTime Created_At { get; set; }

    public string? Tipo_Usuario { get; set; }
}
