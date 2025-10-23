using JpWebApp.Models;

namespace JpWebApp.Data.Repositorio.interfaces
{
    public interface IProfessorRepositorio
    {
        IEnumerable<Professor> GetProfessores();

        IEnumerable<Professor> GetProfessoresComNome(string buscar);

        Professor? GetProfessor(int ID);

        void NovoProfessor(Professor professor);

        void AtualizarProfessor(Professor professor);

        void Excluir(Professor professor);
    }
}
