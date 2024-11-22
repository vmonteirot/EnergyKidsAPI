using System.Collections.Generic;
using EnergyKids.Models;

namespace EnergyKids.Repositories.Interfaces
{
    public interface IDispositivoRepository
    {
        IEnumerable<Dispositivo> GetDispositivos();
        Dispositivo GetDispositivoById(int id);
        void AddDispositivo(Dispositivo dispositivo);
        void DeleteDispositivo(int id);
    }
}
