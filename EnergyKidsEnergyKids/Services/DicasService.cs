using System.Collections.Generic;
using EnergyKids.Models;

namespace EnergyKids.Services
{
    public class DicasService
    {
        public List<DicaEconomia> GerarDicasPersonalizadas(Usuario usuario)
        {
            // Simples lógica para geração de dicas com base em dispositivos cadastrados
            var dicas = new List<DicaEconomia>();

            foreach (var dispositivo in usuario.Dispositivos)
            {
                if (dispositivo.HorasPorDia > 5)
                {
                    dicas.Add(new DicaEconomia
                    {
                        Titulo = $"Reduza o uso do {dispositivo.Nome}",
                        Descricao = $"Considere reduzir o tempo de uso do {dispositivo.Nome} para menos de 5 horas diárias."
                    });
                }
                else
                {
                    dicas.Add(new DicaEconomia
                    {
                        Titulo = $"Ótima gestão do {dispositivo.Nome}",
                        Descricao = $"Seu uso do {dispositivo.Nome} está dentro de um nível eficiente de consumo."
                    });
                }
            }

            return dicas;
        }
    }
}
