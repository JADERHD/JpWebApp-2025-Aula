namespace JpWebApp.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateOnly Data_De_Nascimento { get; set; }

        //endereço
        public string? CEP { get; set; }
        public string? Logradouro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Bairro { get; set; }
        public string? Numero { get; set; }

        //endereço
        // CEP
        //logradouro
        //cidade
        //estado
        //bairro
        //numero
    }
}
