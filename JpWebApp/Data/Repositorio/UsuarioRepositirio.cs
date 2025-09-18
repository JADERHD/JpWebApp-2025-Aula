using JpWebApp.Data.Repositorio.Interfaces;
using JpWebApp.Models;

namespace JpWebApp.Data.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContexto _bancoContexto;

        public UsuarioRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _bancoContexto.Usuario.Add(usuario);
            _bancoContexto.SaveChanges();
        }

        public Usuario? GetUsuarioPorEmail(string email)
        {
           return  _bancoContexto.Usuario.Where(a => a.Email == email).FirstOrDefault();
        }
    }
}
