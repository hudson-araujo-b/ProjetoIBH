using Microsoft.AspNetCore.Mvc;

namespace ProjetoIBH.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
