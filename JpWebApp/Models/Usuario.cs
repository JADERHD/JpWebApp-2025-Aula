namespace JpWebApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? Perfil { get; set; }
    }

    public enum UsuarioPerfil 
    { 
        Indeterminado = 0,
        Admin = 1,
        Usuario = 2,
    }
}
