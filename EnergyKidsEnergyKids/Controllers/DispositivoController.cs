using Microsoft.AspNetCore.Mvc;
using EnergyKids.Models;
using EnergyKids.Services;

namespace EnergyKids.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController : ControllerBase
    {
        private readonly EstimativaConsumoService _estimativaConsumoService;

        public DispositivoController(EstimativaConsumoService estimativaConsumoService)
        {
            _estimativaConsumoService = estimativaConsumoService;
        }

        [HttpGet("{id}/consumo-estimado")]
        public IActionResult CalcularConsumoMensal(int id)
        {
            // Simular busca de dispositivo no banco de dados
            var dispositivo = new Dispositivo
            {
                Id = id,
                Nome = "Geladeira",
                Potencia = 150, // watts
                HorasPorDia = 8
            };

            var consumoEstimado = _estimativaConsumoService.CalcularConsumoMensal(dispositivo);
            return Ok(new { dispositivo.Nome, ConsumoEstimado = consumoEstimado });
        }
    }
}
