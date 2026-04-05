using TiquetesApp.Models;

namespace TiquetesApp.Services
{
    public interface IEventoService
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task CreateAsync(Evento evento);
    }
}