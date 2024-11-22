using System.Collections.Generic;
using System.Linq;
using EnergyKids.Models;
using EnergyKids.Repositories.Interfaces;
using EnergyKids.Data;

namespace EnergyKids.Repositories
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly DataContext _context;

        public DispositivoRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Dispositivo> GetDispositivos()
        {
            return _context.Dispositivos.ToList();
        }

        public Dispositivo GetDispositivoById(int id)
        {
            return _context.Dispositivos.FirstOrDefault(d => d.Id == id);
        }

        public void AddDispositivo(Dispositivo dispositivo)
        {
            _context.Dispositivos.Add(dispositivo);
            _context.SaveChanges();
        }

        public void DeleteDispositivo(int id)
        {
            var dispositivo = GetDispositivoById(id);
            if (dispositivo != null)
            {
                _context.Dispositivos.Remove(dispositivo);
                _context.SaveChanges();
            }
        }
    }
}
