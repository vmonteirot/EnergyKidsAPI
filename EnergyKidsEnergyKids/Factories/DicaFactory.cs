using EnergyKids.Models;

namespace EnergyKids.Factories
{
    public static class DicaFactory
    {
        public static DicaEconomia CriarDicaEficiente(string dispositivoNome)
        {
            return new DicaEconomia
            {
                Titulo = $"Ótima gestão do {dispositivoNome}",
                Descricao = $"Seu uso do {dispositivoNome} está dentro de um nível eficiente de consumo."
            };
        }

        public static DicaEconomia CriarDicaReduzirConsumo(string dispositivoNome)
        {
            return new DicaEconomia
            {
                Titulo = $"Reduza o uso do {dispositivoNome}",
                Descricao = $"Considere reduzir o tempo de uso do {dispositivoNome} para melhorar o consumo energético."
            };
        }
    }
}
