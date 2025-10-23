using JpWebApp.Data.Repositorio.interfaces;
using JpWebApp.Models;

namespace JpWebApp.Data.Repositorio
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public ProfessorRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public IEnumerable<Professor> GetProfessores()
        {
            return _bancoContexto.Professor.ToArray();
        }

        public IEnumerable<Professor> GetProfessoresComNome(string buscar)
        {
            return _bancoContexto.Professor.Where(a => a.NomeCompleto.Contains(buscar));
        }

        public Professor? GetProfessor(int ID)
        {
            return _bancoContexto.Professor.FirstOrDefault(a => a.Id == ID);
        }

        public void NovoProfessor(Professor professor)
        {
            _bancoContexto.Professor.Add(professor);
            _bancoContexto.SaveChanges();
        }

        public void AtualizarProfessor(Professor professor)
        {
            _bancoContexto.Professor.Update(professor);
            _bancoContexto.SaveChanges();
        }

        public void Excluir(Professor professor)
        {
            _bancoContexto.Professor.Remove(professor);
            _bancoContexto.SaveChanges();
        }
    }

}
