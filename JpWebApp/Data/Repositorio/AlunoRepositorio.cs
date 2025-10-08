using JpWebApp.Data.Repositorio.interfaces;
using JpWebApp.Models;

namespace JpWebApp.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public void AtualizarAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Update(aluno);
            _bancoContexto.SaveChanges();
        }

        public void Excluir(Aluno aluno)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }

        public Aluno? GetAluno(int ID)
        {
            return _bancoContexto.Aluno.FirstOrDefault(a => a.Id == ID);
        }

        public IEnumerable<Aluno> GetAlunos()
        {
           return _bancoContexto.Aluno.ToArray();
        }

        public void NovoAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }

        public bool TemAlunoComCpf(string cpf)
        {
            return _bancoContexto.Aluno.FirstOrDefault(a => a.Cpf == cpf) != null;
        }

        public bool TemAlunoComMatricula(string matricula)
        {
            return _bancoContexto.Aluno.FirstOrDefault(a => a.Matricula == matricula) != null;
        }
        public bool TemAlunoComCpf(string cpf, int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(a => a.Cpf == cpf && a.Id != id) != null;
        }

        public bool TemAlunoComMatricula(string matricula, int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(a => a.Matricula == matricula && a.Id != id) != null;
        }

    }
}
