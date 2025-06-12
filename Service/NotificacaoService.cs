using ReconhecimentoFacialApp.Models;
using ReconhecimentoFacialApp.Dtos;
using ReconhecimentoFacialApp.Service.Interface;
using System.Text.Json;
using ReconhecimentoFacialApp.Repositories;

public class NotificacaoService : INotificacaoService
{
    private readonly INotificacaoRepository _repo;

    public NotificacaoService(INotificacaoRepository repo)
    {
        _repo = repo;
    }

    public async Task RegistrarEventoAsync(EventoDispositivoDto dto)
    {
        var evento = new ValidacaoFacial
        {
            Usuario_Id = Guid.TryParse(dto.UsuarioId, out var uid) ? uid : Guid.Empty,
            Tipo_Validacao = dto.Tipo?? "Desconhecido",
            Resultado_Validacao = dto.Resultado,
            Mensagem = dto.Mensagem,
            Data_Validacao = dto.DataHora,
            Imagem_Path = null, 
            Dispositivo_Id = dto.DispositivoId,
            RawPayload = JsonSerializer.Serialize(dto)
        };

        await _repo.AdicionarAsync(evento);
    }
}
