namespace ReconhecimentoFacialApp.Service.Interface;

using ReconhecimentoFacialApp.Dtos;

public interface INotificacaoService
{
    Task RegistrarEventoAsync(EventoDispositivoDto dto);
}
