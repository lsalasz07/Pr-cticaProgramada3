using TiquetesApp.Models;

namespace TiquetesApp.Services
{
    public interface ICompraService
    {
        Task<List<Compra>> GetAllAsync();
        Task<(bool success, string message, Compra? compra)> ComprarAsync(CompraViewModel vm);
    }
}