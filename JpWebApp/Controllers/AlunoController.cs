using JpWebApp.Data.Repositorio;
using JpWebApp.Data.Repositorio.interfaces;
using JpWebApp.Data.Repositorio.Interfaces;
using JpWebApp.Models;
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

        //AdicionarAluno
        public IActionResult AdicionarAluno()
        {
            return View();
        }

        //NovoAluno

        public IActionResult NovoAluno(Aluno aluno)
        {
            //Console.WriteLine("usuario nome "  + usuario.Email);
            //Console.WriteLine("usuario senha "  + usuario.Senha);
            try
            {
                _alunoRepositorio.NovoAluno(aluno);
                TempData["cadastroOK"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao cadastrar aluno";
            }
            return View("AdicionarAluno");
        }

    }
}
