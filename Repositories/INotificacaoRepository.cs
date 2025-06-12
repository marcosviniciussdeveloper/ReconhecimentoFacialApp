namespace ReconhecimentoFacialApp.Repositories
{
    public interface INotificacaoRepository
    {

        Task AdicionarAsync(ValidacaoFacial notificacao);


    }
}
