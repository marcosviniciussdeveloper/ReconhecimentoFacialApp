using Microsoft.AspNetCore.Mvc;
using ReconhecimentoFacialApp.Dtos;
using ReconhecimentoFacialApp.Service.Interface;

namespace ReconhecimentoFacialApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController : ControllerBase
    {
        private readonly INotificacaoService _notificacaoService;

        public DispositivoController(INotificacaoService notificacaoService)
        {
            _notificacaoService = notificacaoService;
        }


        [HttpPost("RegistrarEvento")]

        public async Task<ActionResult> RegistrarEventoAsync ([FromBody] EventoDispositivoDto dto)
            {
                
             if (!ModelState.IsValid)
            return BadRequest(ModelState);


            await _notificacaoService.RegistrarEventoAsync(dto);
            return Ok(new { mensagem = "Evento registrado com sucesso" });

        }

    }







    }

