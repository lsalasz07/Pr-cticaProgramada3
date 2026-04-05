using TiquetesApp.Models;

namespace TiquetesApp.Repositories
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task AddAsync(Evento evento);
        Task SaveAsync();
    }
}