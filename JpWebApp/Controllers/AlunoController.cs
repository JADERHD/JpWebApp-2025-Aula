using JpWebApp.Data.Repositorio;
using JpWebApp.Data.Repositorio.interfaces;
using JpWebApp.Data.Repositorio.Interfaces;
using JpWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JpWebApp.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            this._alunoRepositorio = alunoRepositorio;
        }


        public IActionResult Index(string? buscar)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }


            var alunos = _alunoRepositorio.GetAlunos();
            if (buscar != null)
            {
                alunos = _alunoRepositorio.GetAlunosComNome(buscar);
            }
            
            return View(alunos);
        }

        //AdicionarAluno
        public IActionResult Adicionar(Aluno? aluno)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            if (aluno == null)
            {
                aluno = new Aluno();
            }

            return View(aluno);
        }

        public IActionResult Editar(int id, Aluno? aluno)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            if ( id != 0 )
            {
                aluno = _alunoRepositorio.GetAluno(id);
            }
           
            return View(aluno);
        }


        //Excluir
        public IActionResult Excluir(int id)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            var aluno = _alunoRepositorio.GetAluno(id);
            if (aluno != null)
            {
                _alunoRepositorio.Excluir(aluno);
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        public IActionResult AtualizarAluno(int id, Aluno aluno)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            aluno.Id = id;

            if (Validacoes(aluno))
            {
                return View("Editar", aluno);
            }
            try
            {              
                _alunoRepositorio.AtualizarAluno(aluno);
                TempData["EdicaoOK"] = "Edição realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao editar aluno.\n" + ex.Message;
            }
            return View("Editar", aluno);

        }

        private bool Validacoes(Aluno aluno) 
        {
            bool comErro = false;
            if (aluno == null)
            {
               return true;
            }

            if (aluno.Nome.IsNullOrEmpty())
            {
                TempData["ErroNomeInvalida"] = "Você inseriu um nome nullo ou vazio.";
                comErro = true;
            }

            if (aluno.Nome?.Length < 4)
            {
                TempData["ErroNome"] = "O tamanho do nome deve ter pelo menos 3 caracteres.";
                comErro = true;
            }

            if (aluno.Nome?.Length > 100)
            {
                TempData["ErroNome"] = "O tamanho do nome não pode ter mais de 100 caracteres.";
                comErro = true;
            }

            if (aluno.Matricula.IsNullOrEmpty())
            {
                TempData["ErroMatriculaInvalida"] = "Você inseriu uma matricula invalida.";
                comErro = true;
            }

            if(aluno.Matricula?.Length > 50)
            {
                TempData["ErroMatriculaInvalida"] = "A matricula não pode ter mais de 50 caracteres.";
                comErro = true;
            }

            if (_alunoRepositorio.TemAlunoComMatricula(aluno.Matricula, aluno.Id))
            {
                TempData["ErroMatriculaInvalida"] = "Já existe um aluno com essa matricula.";
                comErro = true;
            }

            if (aluno.Cpf.IsNullOrEmpty())
            {
                TempData["ErroCPFInvalida"] = "Você inseriu um cpf invalido.";
                comErro = true;
            }


            if (aluno.Cpf?.Length > 14)
            {
                TempData["ErroCPFInvalida"] = "O cpf não pode ter mais de 14 caracteres.";
                comErro = true;
            }

            if (_alunoRepositorio.TemAlunoComCpf(aluno.Cpf, aluno.Id))
            {
                TempData["ErroCPFInvalida"] = "Já existe um aluno com esse cpf.";
                comErro = true;
            }

            if (aluno.CEP.IsNullOrEmpty())
            {
                TempData["ErroCepInvalida"] = "Você inseriu um cep invalido.";
                comErro = true;
            }

            if (aluno.CEP?.Length != 8)
            {
                TempData["ErroCepInvalida"] = "O cep tem que ter exatamente 8 caracteres.";
                comErro = true;
            }

            if (aluno.Logradouro.IsNullOrEmpty())
            {
                TempData["ErroEnderecoInvalida"] = "Você inseriu um logradouro invalido.";
                comErro = true;
            }

            if (aluno.Logradouro?.Length > 100)
            {
                TempData["ErroEnderecoInvalida"] = "O logradouro não pode ter mais de 100 caracteres.";
                comErro = true;
            }

            if (aluno.Bairro.IsNullOrEmpty())
            {
                TempData["ErroBairroInvalida"] = "Você inseriu um bairro invalido.";
                comErro = true;
            }

            if (aluno.Bairro?.Length > 100)
            {
                TempData["ErroBairroInvalida"] = "O bairro não pode ter mais de 100 caracteres.";
                comErro = true;
            }

            if (aluno.Cidade.IsNullOrEmpty())
            {
                TempData["ErroCidadeInvalida"] = "Você inseriu uma cidade invalida.";
                comErro = true;
            }

            if (aluno.Cidade?.Length > 100)
            {
                TempData["ErroCidadeInvalida"] = "A cidade não pode ter mais de 100 caracteres.";
                comErro = true;
            }

            if (aluno.Numero.IsNullOrEmpty())
            {
                TempData["ErroNumeroInvalida"] = "Você inseriu um numero nulo.";
                comErro = true;
            }

            if (aluno.Numero?.Length > 50)
            {
                TempData["ErroNumeroInvalida"] = "O numero não pode ter mais de 50 caracteres.";
                comErro = true;
            }

            if (aluno.Estado.IsNullOrEmpty())
            {
                TempData["ErroEstadoInvalido"] = "Você inseriu um estado invalido.";
                comErro = true;
            }

            if (aluno.Estado?.Length != 2)
            {
                TempData["ErroEstadoInvalido"] = "O estado deve ser prenchido com 2 caracteres.";
                comErro = true;
            }

            return comErro;
        }

        [HttpPost()]
        public IActionResult NovoAluno(Aluno aluno)
        {
            if (HttpContext.Session.GetString("usuarioPerfil") != UsuarioPerfil.Admin.ToString())
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            if (Validacoes(aluno))
            {
                return View("Adicionar", aluno);
            }

            try
            {
                _alunoRepositorio.NovoAluno(aluno);
                TempData["cadastroOK"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao cadastrar aluno.\n" + ex.Message;
            }
            return View("Adicionar", aluno);
        }

    }
}
