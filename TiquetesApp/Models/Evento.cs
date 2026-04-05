namespace TiquetesApp.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int CantidadDisponible { get; set; }

        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}