using TiquetesApp.Models;

namespace TiquetesApp.Repositories
{
    public interface ICompraRepository
    {
        Task<List<Compra>> GetAllAsync();
        Task AddAsync(Compra compra);
        Task SaveAsync();
    }
}