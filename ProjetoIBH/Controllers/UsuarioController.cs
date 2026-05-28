using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjetoIBH.Interfaces;
using ProjetoIBH.Models;
using ProjetoIBH.Repository;
using System.Security.Claims;

namespace ProjetoIBH.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CriarConta() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarConta(CriarContaViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.CriarConta(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }


        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
