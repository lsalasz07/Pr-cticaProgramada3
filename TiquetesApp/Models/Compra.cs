namespace TiquetesApp.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCompra { get; set; }

        public Evento? Evento { get; set; }
    }
}