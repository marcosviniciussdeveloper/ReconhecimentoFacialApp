
using ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos;
using static ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos.ValidacaoFacialDto;

namespace ReconhecimentoFacialApp.Service.Interface
{
    public interface IValidacaoService
    {
        Task<Guid> CriarAsync(CreateValidacaoDto dto);
        Task<bool> AtualizarAsync(UpdateValidacaoDto dto);
        Task<bool> ExcluirAsync(Guid id);
        Task<IEnumerable<ReadValidacaoDto>> ListarPorUsuarioAsync(string Cpf );
    }
}
