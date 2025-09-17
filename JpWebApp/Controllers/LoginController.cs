using JpWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JpWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidaUsuario(Usuario usuario)
        {
            try
            {
                if (usuario.Email == "email@email.com" && usuario.Senha == "123456789")
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
 
            }

            TempData["MsgErro"] = "usuario ou senha esta errado! tente novamente...";


            return View("Index");
            //return RedirectToAction("Index", "Login");
            //return Redirect("/Home");
        }

        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
