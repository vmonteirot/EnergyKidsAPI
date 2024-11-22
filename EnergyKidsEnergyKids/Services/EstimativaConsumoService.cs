using System.Linq;
using EnergyKids.Models;

namespace EnergyKids.Services
{
    public class EstimativaConsumoService
    {
        public double CalcularConsumoMensal(Dispositivo dispositivo)
        {
            // Fórmula: Consumo mensal (kWh) = Potência (kW) * Horas por dia * 30 dias
            return (dispositivo.Potencia / 1000) * dispositivo.HorasPorDia * 30;
        }
    }
}
