

using ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos;
using static ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos.ValidacaoFacialDto;

namespace ReconhecimentoFacialApp.Repositories
{
    public interface IValidacaoRepository
    {

        Task<Guid> CreateAsync(CreateValidacaoDto dto);
        Task<bool> UpdateAsync(UpdateValidacaoDto dto);
        Task<IEnumerable<ReadValidacaoDto>> GetAllByValidacaoReadAysnc(string Cpf );
        Task<bool> DeleteAsync(Guid ValidacaoId);
    }





}

