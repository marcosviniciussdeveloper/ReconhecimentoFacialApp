using Microsoft.AspNetCore.Mvc;
using ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos;
using ReconhecimentoFacialApp.Service.Interface;
using static ReconhecimentoFacialApp.Dtos.ValidacaoFacialDtos.ValidacaoFacialDto;

namespace ReconhecimentoFacialApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidacaoController : ControllerBase
    {
        private readonly IValidacaoService _validacaoService;

        public ValidacaoController(IValidacaoService validacaoService)
        {
            _validacaoService = validacaoService;
        }

      
        [HttpPost ("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreateValidacaoDto dto)
        {
            try
            {
                var id = await _validacaoService.CriarAsync(dto);
                return Ok(new { mensagem = "Validação registrada com sucesso", id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

       
        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar( [FromBody] UpdateValidacaoDto dto)
        {
            if (!dto.ValidacaoId.HasValue)
                return BadRequest("O id é obrigatorio.");

            var sucesso = await _validacaoService.AtualizarAsync(dto);
            return sucesso ? Ok(new { mensagem = "Usuário atualizado com sucesso." }) : NotFound();

        }

    
        [HttpDelete("Deletar")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var sucesso = await _validacaoService.ExcluirAsync(id);
                return sucesso ? Ok(new { mensagem = "Validação excluída com sucesso." }) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> ListarPorUsuario(string Cpf )
        {
            try
            {
                var lista = await _validacaoService.ListarPorUsuarioAsync(Cpf );
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}


