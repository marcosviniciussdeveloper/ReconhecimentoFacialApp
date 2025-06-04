using ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos;
using ReconhecimentoFacialApp.Repositories;
using ReconhecimentoFacialApp.Service.Interface;
using static ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos.ValidacaoFacialDto;
namespace ReconhecimentoFacialApp.Service
{
  

    

    public class ValidacaoService : IValidacaoService
    {

        private readonly IValidacaoRepository _repository;


        public ValidacaoService(IValidacaoRepository repository)
        {

            _repository = repository;
        }

        public async Task<bool> AtualizarAsync(UpdateValidacaoDto dto)
        {
            return await _repository.UpdateAsync(dto);
        }

        public async Task<Guid> CriarAsync(CreateValidacaoDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        public async Task<bool> ExcluirAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReadValidacaoDto>> ListarPorUsuarioAsync(string Cpf )
        {
            return await _repository.GetAllByValidacaoReadAysnc(Cpf);
        }
    }
}