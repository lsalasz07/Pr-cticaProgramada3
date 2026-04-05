using Microsoft.EntityFrameworkCore;
using TiquetesApp.Data;
using TiquetesApp.Models;

namespace TiquetesApp.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly AppDbContext _context;

        public CompraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Compra>> GetAllAsync() =>
            await _context.Compras.Include(c => c.Evento).ToListAsync();

        public async Task AddAsync(Compra compra) =>
            await _context.Compras.AddAsync(compra);

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}