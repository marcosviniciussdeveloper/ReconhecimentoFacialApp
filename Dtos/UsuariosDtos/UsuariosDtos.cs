using System.ComponentModel.DataAnnotations;

public class CreateUsuarioDto
{
    public Guid? Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Cpf { get; set; }

    public string? ImgCodigo { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public string? TipoUsuario { get; set; }
}

public class UpdateUsuarioDto
{
    public Guid? Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? ImgCodigo { get; set; }
    public string? TipoUsuario { get; set; }
}

public class ReadUsuarioDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? ImgCodigo { get; set; }
    public string Cpf { get; set; }
    public string? TipoUsuario { get; set; }
    public DateTime CreatedAt { get; set; }
}
