

namespace ReconhecimentoFacialApp.Service.Interface
{
    public interface IUsuariosService
    {
        Task<Guid> CriarAsync(CreateUsuarioDto dto);
        Task<bool> AtualizarAsync(UpdateUsuarioDto dto);
        Task<bool> ExcluirAsync(string Cpf );

        Task<ReadUsuarioDto?> ObterPorCpfAsync(string Cpf);
    }
}
