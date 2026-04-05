using TiquetesApp.Models;
using TiquetesApp.Repositories;

namespace TiquetesApp.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _repo;

        public EventoService(IEventoRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Evento>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Evento?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task CreateAsync(Evento evento)
        {
            await _repo.AddAsync(evento);
            await _repo.SaveAsync();
        }
    }
}