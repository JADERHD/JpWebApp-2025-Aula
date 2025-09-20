using JpWebApp.Models;
using System.Collections;

namespace JpWebApp.Data.Repositorio.interfaces
{
    public interface IAlunoRepositorio
    {
        IEnumerable<Aluno> GetAlunos();
    }
}
