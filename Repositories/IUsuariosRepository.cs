


namespace ReconhecimentoFacialApp.Repositorios
{
    public interface IUsuariosRepository
    {
        Task<Guid> CreateAsync(CreateUsuarioDto dto);
        Task<bool> UpdateAsync(UpdateUsuarioDto dto);
 
        Task<bool> DeleteAsync(string Cpf);
        Task<IEnumerable<ReadUsuarioDto>> GetAllByUsuariosReadAysnc(Guid usuarioId);


        Task<ReadUsuarioDto?> ObterPorCpfAsync(string cpf);
    }
}
