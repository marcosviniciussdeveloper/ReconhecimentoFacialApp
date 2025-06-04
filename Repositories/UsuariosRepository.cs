using Microsoft.EntityFrameworkCore;
using ReconhecimentoFacialApp.Data;
using ReconhecimentoFacialApp.Models;


namespace ReconhecimentoFacialApp.Repositorios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AppDbContext _context;

        public UsuariosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(CreateUsuarioDto dto)
        {
            var novoUsuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Img_Codigo = dto.ImgCodigo,
                Created_At = dto.CreatedAt ?? DateTime.UtcNow,
              
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return novoUsuario.Id;
        }

        public async Task<bool> DeleteAsync(string cpf)
        {
            var usuario = await _context.Usuarios.FindAsync(cpf);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
          
            return true;
        }

        public Task<IEnumerable<ReadUsuarioDto>> GetAllByUsuariosReadAysnc(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadUsuarioDto?> ObterPorCpfAsync(string cpf)
        {
             var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Cpf == cpf);
            if (usuario == null)
                return null;

            return new ReadUsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                ImgCodigo = usuario.Img_Codigo,
                Cpf = usuario.Cpf,
                TipoUsuario = usuario.Tipo_Usuario,
                CreatedAt = usuario.Created_At



            };
        }

        public async Task<bool> UpdateAsync(UpdateUsuarioDto dto)
        {
            if (!dto.Id.HasValue)
                throw new ArgumentException("ID não pode ser nulo");

            var usuario = await _context.Usuarios.FindAsync(dto.Id.Value);
            if (usuario == null)
                return false;

            usuario.Nome = dto.Nome ?? usuario.Nome;
            usuario.Cpf = dto.Cpf ?? usuario.Cpf;
            usuario.Img_Codigo = dto.ImgCodigo ?? usuario.Img_Codigo;
           

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
