using Microsoft.AspNetCore.Mvc;

namespace TiquetesApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View();
        public IActionResult Register() => View();
    }
}