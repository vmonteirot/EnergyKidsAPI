using System.Collections.Generic;
using EnergyKids.Models;
using EnergyKids.Services;
using Xunit;

namespace EnergyKids.Tests
{
    public class GeradorDicasServiceTests
    {
        [Fact]
        public void GerarDicasComBaseNoConsumo_DeveGerarDicaParaConsumoExcessivo()
        {
            // Arrange
            var dispositivos = new List<Dispositivo>
            {
                new Dispositivo { Nome = "Ar Condicionado", Potencia = 2000, HorasPorDia = 10 },
                new Dispositivo { Nome = "Ventilador", Potencia = 50, HorasPorDia = 5 }
            };
            var service = new GeradorDicasService();

            // Act
            var dicas = service.GerarDicasComBaseNoConsumo(dispositivos);

            // Assert
            Assert.Equal(2, dicas.Count);
            Assert.Contains(dicas, d => d.Titulo.Contains("Reduza o uso de Ar Condicionado"));
            Assert.Contains(dicas, d => d.Titulo.Contains("Consumo do Ventilador está em nível eficiente"));
        }
    }
}
