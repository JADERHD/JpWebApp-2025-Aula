using JpWebApp.Data.Repositorio.interfaces;
using JpWebApp.Models;

namespace JpWebApp.Data.Repositorio
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public TurmaRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public IEnumerable<Turma> GetTurmas()
        {
            return _bancoContexto.Turma.ToArray();
        }
    }
}
