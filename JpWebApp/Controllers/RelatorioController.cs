using JpWebApp.Data.Repositorio.interfaces;
using JpWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JpWebApp.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly ITurmaRepositorio _turmaRepositorio;

        public RelatorioController(IAlunoRepositorio alunoRepositorio, ITurmaRepositorio turmaRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _turmaRepositorio = turmaRepositorio;
        }

        public IActionResult index()
        {
            var alunos = _alunoRepositorio.GetAlunos();
            var turmas = _turmaRepositorio.GetTurmas();
            var relatorios = alunos.Select(x => new RelatorioViewModel
            {
                Aluno = x,
                Turma = turmas.FirstOrDefault(a => a.Id == x.IdTurma)
            }).ToList();

            return View(relatorios);
        }
    }
}
