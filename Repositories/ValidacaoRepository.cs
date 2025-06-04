using Microsoft.EntityFrameworkCore;
using ReconhecimentoFacialApp.Data;
using ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos;
using ReconhecimentoFacialApp.Models;
using static ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos.ValidacaoFacialDto;


namespace ReconhecimentoFacialApp.Repositories
{

    public class ValidacaoRepository : IValidacaoRepository
    {
        private readonly AppDbContext _context; 


        public ValidacaoRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<Guid> CreateAsync(CreateValidacaoDto dto)
        {
            var novavalidacao = new ValidacaoFacial
            {
                Id = Guid.NewGuid(),
                Usuario_Id = dto.UsuarioId,
                Data_Validacao = dto.DataValidacao,
                Tipo_Validacao = dto.TipoValidacao,
            };

            _context.ValidacoesFaciais.Add(novavalidacao);
            await _context.SaveChangesAsync();

            return novavalidacao.Id;
        }

        public async Task<bool> DeleteAsync(Guid ValidacaoId)
        {
           var existente = await _context.ValidacoesFaciais
                .FirstOrDefaultAsync(v => v.Id == ValidacaoId);

            if (existente == null)
                throw new KeyNotFoundException("Validação facial não encontrada.");


            _context.ValidacoesFaciais.Remove(existente);
            await _context.SaveChangesAsync();

            return true;


        }

        public async Task<IEnumerable<ReadValidacaoDto>> GetAllByValidacaoReadAysnc(string Cpf)
        {
            var resultado = await _context.ValidacoesFaciais 
               .Where(v => v.Usuario.Cpf == Cpf)
                .ToListAsync();

            return resultado.Select(v => new ReadValidacaoDto
            {
                ValidacaoId = v.Id,
                UsuarioId = v.Usuario_Id,
                TipoValidacao = v.Tipo_Validacao,
                ResultadoValidacao = v.Resultado_Validacao,
                DataValidacao = v.Data_Validacao,
                ImagemPath = v.Imagem_Path,
                Reconhecido = !string.IsNullOrEmpty(v.Resultado_Validacao) 
            });
        }

        public async Task<bool> UpdateAsync(UpdateValidacaoDto dto)
        {
            var update = new ValidacaoFacial
            {

                Id = Guid.NewGuid(),
                Usuario_Id = dto.UsuarioId,
                Data_Validacao = dto.DataValidacao,
                Tipo_Validacao = dto.TipoValidacao,
                Resultado_Validacao = dto.ResultadoValidacao,
                Imagem_Path = dto.ImagemPath,

            };

            var resposta = await _context.ValidacoesFaciais
                .Where(v => v.Id == dto.ValidacaoId)
                .FirstOrDefaultAsync();

             return resposta != null && await _context.SaveChangesAsync() > 0;
        }

    }
}