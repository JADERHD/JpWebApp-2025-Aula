using JpWebApp.Models;

namespace JpWebApp.Data.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public void CadastrarUsuario(Usuario usuario);

        public Usuario? GetUsuarioPorEmail(string email);
    }
}
