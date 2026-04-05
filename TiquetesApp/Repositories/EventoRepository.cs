using Microsoft.EntityFrameworkCore;
using TiquetesApp.Data;
using TiquetesApp.Models;

namespace TiquetesApp.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext _context;

        public EventoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> GetAllAsync() =>
            await _context.Eventos.ToListAsync();

        public async Task<Evento?> GetByIdAsync(int id) =>
            await _context.Eventos.FindAsync(id);

        public async Task AddAsync(Evento evento) =>
            await _context.Eventos.AddAsync(evento);

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}