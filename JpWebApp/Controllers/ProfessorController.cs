using JpWebApp.Data.Repositorio.interfaces;
using JpWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JpWebApp.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessorController(IProfessorRepositorio professorRepositorio)
        {
            this._professorRepositorio = professorRepositorio;
        }


        public IActionResult Index(string? buscar)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }


            var profs = _professorRepositorio.GetProfessores();
            if (buscar != null)
            {
                profs = _professorRepositorio.GetProfessoresComNome(buscar);
            }

            return View(profs);
        }

        public IActionResult Adicionar(Professor? prof)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            if (prof == null)
            {
                prof = new Professor();
            }

            return View(prof);
        }

        public IActionResult Editar(int id, Professor? prof)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            if (id != 0)
            {
                prof = _professorRepositorio.GetProfessor(id);
            }

            return View(prof);
        }


        //Excluir
        public IActionResult Excluir(int id)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            var prof = _professorRepositorio.GetProfessor(id);
            if (prof != null)
            {
                _professorRepositorio.Excluir(prof);
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        public IActionResult AtualizarProfessor(int id, Professor prof)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            prof.Id = id;

            if (Validacoes(prof))
            {
                return View("Editar", prof);
            }
            try
            {
                _professorRepositorio.AtualizarProfessor(prof);
                TempData["EdicaoOK"] = "Edição realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao editar professor.\n" + ex.Message;
            }
            return View("Editar", prof);

        }

        private bool Validacoes(Professor prof)
        {
            bool comErro = false;
            if (prof == null)
            {
                return true;
            }

            if (prof.NomeCompleto.IsNullOrEmpty())
            {
                TempData["ErroNomeInvalida"] = "Você inseriu um nome nullo ou vazio.";
                comErro = true;
            }

            if (prof.NomeCompleto?.Length < 4)
            {
                TempData["ErroNome"] = "O tamanho do nome deve ter pelo menos 3 caracteres.";
                comErro = true;
            }

            if (prof.NomeCompleto?.Length > 100)
            {
                TempData["ErroNome"] = "O tamanho do nome não pode ter mais de 100 caracteres.";
                comErro = true;
            }

            if (prof.Email.IsNullOrEmpty())
            {
                TempData["ErroEmailInvalido"] = "Você inseriu um email invalido.";
                comErro = true;
            }

            if (prof.Email?.Length > 50)
            {
                TempData["ErroEmailInvalido"] = "O email não pode ter mais de 50 caracteres.";
                comErro = true;
            }

            if (prof.Email?.Contains("@") == false)
            {
                TempData["ErroEmailInvalido"] = "O email tem que ter o @.";
                comErro = true;
            }

            if (prof.Disciplina.IsNullOrEmpty())
            {
                TempData["ErroDisciplinaInvalida"] = "Você inseriu uma disciplina invalido.";
                comErro = true;
            }

            if (prof.Disciplina?.Length > 50)
            {
                TempData["ErroDisciplinaInvalida"] = "A disciplina não pode ter mais de 50 caracteres.";
                comErro = true;
            }

            return comErro;
        }

        [HttpPost()]
        public IActionResult NovoProfessor(Professor prof)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            if (Validacoes(prof))
            {
                return View("Adicionar", prof);
            }

            try
            {
                _professorRepositorio.NovoProfessor(prof);
                TempData["cadastroOK"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao cadastrar professor.\n" + ex.Message;
            }
            return View("Adicionar", prof);
        }

    }
}
