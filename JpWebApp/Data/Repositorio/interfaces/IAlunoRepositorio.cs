using JpWebApp.Models;
using System.Collections;

namespace JpWebApp.Data.Repositorio.interfaces
{
    public interface IAlunoRepositorio
    {
        IEnumerable<Aluno> GetAlunos();

        Aluno? GetAluno(int ID);

        void NovoAluno(Aluno aluno);

        void AtualizarAluno(Aluno aluno);

        void Excluir(Aluno aluno);

        bool TemAlunoComMatricula(string matricula);

        bool TemAlunoComCpf(string cpf);

        bool TemAlunoComMatricula(string matricula, int id);

        bool TemAlunoComCpf(string cpf, int id);
    }
}
