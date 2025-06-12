using ReconhecimentoFacialApp.Data;
using ReconhecimentoFacialApp.Repositories;

public class NotificacaoRepository : INotificacaoRepository
{
    private readonly AppDbContext _context;

    public NotificacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(ValidacaoFacial notificacao)
        {
          _context.ValidacoesFaciais.Add(notificacao);
        await _context.SaveChangesAsync();
        }
    }

