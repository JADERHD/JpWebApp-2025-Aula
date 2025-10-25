using JpWebApp.Models;

namespace JpWebApp.Data.Repositorio.interfaces
{
    public interface ITurmaRepositorio
    {
        IEnumerable<Turma> GetTurmas();
    }
}
