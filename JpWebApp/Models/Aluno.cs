namespace JpWebApp.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateOnly Data_De_Nascimento { get; set; }
    }
}
