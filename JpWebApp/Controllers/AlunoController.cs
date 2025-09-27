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
        public IActionResult Adicionar(Aluno aluno)
        {
            if (aluno == null)
            {
                aluno = new Aluno();
            }
            return View(aluno);
        }

        public IActionResult Editar(int id)
        {
            var aluno = _alunoRepositorio.GetAluno(id);
            return View(aluno);
        }


        //Excluir
        public IActionResult Excluir(int id)
        {
            var aluno = _alunoRepositorio.GetAluno(id);
            if (aluno != null)
            {
                _alunoRepositorio.Excluir(aluno);
            }
            return RedirectToAction("Index");
        }


        //RetornoEditarAluno

        public IActionResult AtualizarAluno(int id, Aluno aluno)
        {
            try
            {
                aluno.Id = id;
                _alunoRepositorio.AtualizarAluno(aluno);
                TempData["EdicaoOK"] = "Edição realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao editar aluno.";
            }
            return View("EditarAluno");

        }


        //NovoAluno

        public IActionResult NovoAluno(Aluno aluno)
        {
            bool comErro = false;

            if (aluno == null) 
            {
                comErro = true;
            }

            if (aluno.Nome.Length < 4) 
            {
                TempData["ErroNome"] = "O tamanho do nome deve ter pelo menos 3 caracteres!";
                comErro = true;
            }


            if (comErro) 
            {
                return View("Adicionar", aluno);
            }

            try
            {
                _alunoRepositorio.NovoAluno(aluno);
                TempData["cadastroOK"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao cadastrar aluno.";
            }
            return View("AdicionarAluno");
        }

    }
}
