using JpWebApp.Data.Repositorio.Interfaces;
using JpWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JpWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio _usuarioRepositorio)
        {
            this._usuarioRepositorio = _usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidaUsuario(Usuario usuario)
        {
            try
            {
                var retorno = _usuarioRepositorio.ValidarUsuario(usuario);
                if (retorno != null)
                {

                    this.HttpContext.Session.SetString("usuarioPerfil", ((UsuarioPerfil)(retorno.Perfil ?? 0)).ToString());
                    return RedirectToAction("Index", "Home");
                }

                /*
                var usuarioDb = _usuarioRepositorio.GetUsuarioPorEmail(usuario.Email);

                if (usuario.Email == usuarioDb?.Email && usuario.Senha == usuarioDb?.Senha)
                {
                    return RedirectToAction("Index", "Home");
                }
                */
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

        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            //Console.WriteLine("usuario nome "  + usuario.Email);
            //Console.WriteLine("usuario senha "  + usuario.Senha);
            try
            {
                _usuarioRepositorio.CadastrarUsuario(usuario);
                TempData["cadastroOK"] = "Cadastro realizado com sucesso!";
                return View("Index");
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao cadastrar usuário";
            }
            return View("Cadastro");
        }
    }
}
