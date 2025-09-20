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

        public IEnumerable<Aluno> GetAlunos()
        {
           return _bancoContexto.Aluno.ToArray();
        }
    }
}
