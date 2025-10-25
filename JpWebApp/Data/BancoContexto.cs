using JpWebApp.Data.Mapeamento;
using JpWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JpWebApp.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {
            CriarTabelas();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
            modelBuilder.ApplyConfiguration(new ProfessorMapeamento());
            modelBuilder.ApplyConfiguration(new TurmaMapeamento());
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma { get; set; }

        public void CriarTabelas()
        {
            var createUsuarioQuery = """
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Usuario' AND xtype = 'U')
                CREATE TABLE Usuario (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Email VARCHAR(50) NOT NULL,
                    Senha VARCHAR(50) NOT NULL,
                    Perfil INT NULL
                );
                """;
            this.Database.ExecuteSqlRaw(createUsuarioQuery);

            var createAlunoQuery = """
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Aluno' AND xtype = 'U')
                CREATE TABLE Aluno (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Matricula VARCHAR(50) NOT NULL,
                    Nome VARCHAR(100) NOT NULL,
                    Cpf VARCHAR(14) NOT NULL,
                    Data_De_Nascimento DATE NOT NULL,
                    CEP VARCHAR(9) NULL,
                    Logradouro VARCHAR(100) NULL,
                    Cidade VARCHAR(100) NULL,
                    Estado VARCHAR(2) NULL,
                    Bairro VARCHAR(100) NULL,
                    Numero VARCHAR(50) NULL,
                    IdTurma INT NULL
                );
                """;
            this.Database.ExecuteSqlRaw(createAlunoQuery);

            var createProfessorQuery = """
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Professor' AND xtype = 'U')
                CREATE TABLE Professor (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Disciplina VARCHAR(50) NOT NULL,
                    NomeCompleto VARCHAR(100) NOT NULL,
                    Email VARCHAR(50) NOT NULL
                );
                """;
            this.Database.ExecuteSqlRaw(createProfessorQuery);

            var createTurmaQuery = """
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Turma' AND xtype = 'U')
                CREATE TABLE Turma (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nome VARCHAR(50) NOT NULL,
                    DataInicio DATE NOT NULL,
                    DataFim DATE NOT NULL
                );
                """;
            this.Database.ExecuteSqlRaw(createTurmaQuery);

        }
    }

}
