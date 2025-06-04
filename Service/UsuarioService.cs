using ReconhecimentoFacialApp.Repositorios;
using ReconhecimentoFacialApp.Service.Interface;

public class UsuarioService : IUsuariosService
{
    private readonly IUsuariosRepository _repository;

    public UsuarioService(IUsuariosRepository repository)
    {
        _repository = repository;
    }

    public Task<Guid> CriarAsync(CreateUsuarioDto dto) => _repository.CreateAsync(dto);

    public Task<bool> AtualizarAsync(UpdateUsuarioDto dto) => _repository.UpdateAsync(dto);

    public Task<bool> ExcluirAsync(string Cpf) => _repository.DeleteAsync(Cpf);

  

    public Task<IEnumerable<ReadUsuarioDto>> ObterTodosPorIdAsync(Guid usuarioId) =>
        _repository.GetAllByUsuariosReadAysnc(usuarioId);

    public Task<IEnumerable<ReadUsuarioDto>> ObterTodosPorCpfAsync(string Cpf)
    {
        throw new NotImplementedException();
    }

    public Task<ReadUsuarioDto?> ObterPorCpfAsync(string Cpf)
    {
        return _repository.ObterPorCpfAsync(Cpf);
    }
}
