namespace ReconhecimentoFacialApp.Dtos;

public class EventoDispositivoDto
{
    public string? DispositivoId { get; set; } 
    public string? UsuarioId { get; set; }   
    public string? Resultado { get; set; }     
    public string? Mensagem { get; set; }      
    public string?  Tipo { get; set; } // "Facial", "Cartão", "Senha"
    public string? ImagemBase64 { get; set; } 
    public DateTime DataHora { get; set; }    
}
