using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TiquetesApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult CrearEvento() => View();
        public IActionResult Historial() => View();
    }
}