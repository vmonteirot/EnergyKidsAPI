namespace EnergyKids.Models
{
    public class ConsumoEnergia
    {
        public int Id { get; set; }
        public int DispositivoId { get; set; }
        public Dispositivo Dispositivo { get; set; }
        public double ConsumoMensal { get; set; } // Consumo estimado em kWh
    }
}
