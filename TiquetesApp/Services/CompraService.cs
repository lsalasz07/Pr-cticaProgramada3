using TiquetesApp.Models;
using TiquetesApp.Repositories;

namespace TiquetesApp.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepo;
        private readonly IEventoRepository _eventoRepo;

        public CompraService(ICompraRepository compraRepo, IEventoRepository eventoRepo)
        {
            _compraRepo = compraRepo;
            _eventoRepo = eventoRepo;
        }

        public Task<List<Compra>> GetAllAsync() => _compraRepo.GetAllAsync();

        public async Task<(bool success, string message, Compra? compra)> ComprarAsync(CompraViewModel vm)
        {
            var evento = await _eventoRepo.GetByIdAsync(vm.EventoId);

            if (evento == null)
                return (false, "Evento no encontrado.", null);

            if (vm.Cantidad <= 0)
                return (false, "La cantidad debe ser mayor a 0.", null);

            if (evento.CantidadDisponible < vm.Cantidad)
                return (false, $"Solo hay {evento.CantidadDisponible} tiquetes disponibles.", null);

            evento.CantidadDisponible -= vm.Cantidad;
            await _eventoRepo.SaveAsync();

            var compra = new Compra
            {
                EventoId = vm.EventoId,
                NombreCliente = vm.NombreCliente,
                Cantidad = vm.Cantidad,
                Total = evento.Precio * vm.Cantidad,
                FechaCompra = DateTime.Now
            };

            await _compraRepo.AddAsync(compra);
            await _compraRepo.SaveAsync();

            return (true, "Compra realizada con éxito.", compra);
        }
    }
}