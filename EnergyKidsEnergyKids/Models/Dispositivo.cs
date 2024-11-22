namespace EnergyKids.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Potencia { get; set; } // Potência em watts
        public int HorasPorDia { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
