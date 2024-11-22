using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EnergyKids.Models;
using EnergyKids.Services;

namespace EnergyKids.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DicasService _dicasService;

        public UsuarioController(DicasService dicasService)
        {
            _dicasService = dicasService;
        }

        [HttpGet("{id}/dicas")]
        public IActionResult GerarDicasPersonalizadas(int id)
        {
            // Simular busca de usuário no banco de dados
            var usuario = new Usuario
            {
                Id = id,
                Nome = "Teste",
                Dispositivos = new List<Dispositivo>
                {
                    new Dispositivo { Nome = "Geladeira", Potencia = 150, HorasPorDia = 8 },
                    new Dispositivo { Nome = "TV", Potencia = 100, HorasPorDia = 4 }
                }
            };

            var dicas = _dicasService.GerarDicasPersonalizadas(usuario);
            return Ok(dicas);
        }
    }
}
