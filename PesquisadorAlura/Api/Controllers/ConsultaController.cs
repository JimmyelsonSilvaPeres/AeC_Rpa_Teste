using AppServices.DTO;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        /// <summary>Inicia o processo de consulta no alura Alura</summary>
        /// <response code="200">Consulta iniciada com sucesso</response>
        /// <response code="400">Texto a ser consulta nulo e vazio. </response>

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Consulta(ConsultaDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Texto))
                return BadRequest("Texto de consulta não preenchido.");

            await  Task.Run(() => _consultaService.Consulta(dto.Texto));


            return Ok("Foi iniciada a raspagem.");
        }

        /// <summary>Vizualiza Todas pesquisas</summary>
        /// <response code="200">Pesquisa retornada com sucesso</response>

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Vizualizar()
        {
            return Ok(_consultaService.VizualizarConsultas());
        }
    }
}
