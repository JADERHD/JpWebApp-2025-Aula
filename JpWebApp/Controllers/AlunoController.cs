using JpWebApp.Data.Repositorio.interfaces;
using JpWebApp.Data.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JpWebApp.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            this._alunoRepositorio = alunoRepositorio;
        }


        public IActionResult Index()
        {
            var alunos = _alunoRepositorio.GetAlunos();

            return View(alunos);
        }
    }
}
