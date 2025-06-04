using Microsoft.AspNetCore.Mvc;
using ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos;
using ReconhecimentoFacialApp.Service;
using ReconhecimentoFacialApp.Service.Interface;


namespace ReconhecimentoFacialApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUsuarioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var id = await _usuariosService.CriarAsync(dto);
                return CreatedAtAction(nameof(ObterPorCpf), new { id }, new { mensagem = "Usuário criado com sucesso", id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarAsync([FromBody] UpdateUsuarioDto dto)
        {

            if (dto.Id == null || dto.Id == Guid.Empty)
                return BadRequest(new { mensagem = "O id é obrigatório." });

            var sucesso = await _usuariosService.AtualizarAsync(dto);

            return sucesso
                ? Ok(new { mensagem = "Usuário atualizado com sucesso." })
                : NotFound(new { mensagem = "Usuário não encontrado." });
        }



            [HttpDelete("Deletar")]
        public async Task<IActionResult> Excluir(string Cpf )
        {
            try
            {
                var sucesso = await _usuariosService.ExcluirAsync(Cpf);
                return sucesso
                    ? Ok(new { mensagem = "Usuário excluído com sucesso." })
                    : NotFound(new { erro = "Usuário não encontrado." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> ObterPorCpf(string Cpf)
        {
            try
            {
                var usuario =await _usuariosService.ObterPorCpfAsync(Cpf);
                return usuario == null
                    ? NotFound(new { erro = "Usuário não encontrado." })
                    : Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
