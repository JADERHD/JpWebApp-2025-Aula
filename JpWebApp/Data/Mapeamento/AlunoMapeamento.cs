using JpWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JpWebApp.Data.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Matricula).HasColumnType("varchar(50)");
            builder.Property(t => t.Nome).HasColumnType("varchar(100)");
            builder.Property(t => t.Cpf).HasColumnType("varchar(14)");
            builder.Property(t => t.Data_De_Nascimento).HasColumnType("date");


            builder.Property(t => t.CEP).HasColumnType("varchar(9)");
            builder.Property(t => t.Logradouro).HasColumnType("varchar(100)");
            builder.Property(t => t.Cidade).HasColumnType("varchar(100)");
            builder.Property(t => t.Estado).HasColumnType("varchar(2)");
            builder.Property(t => t.Bairro).HasColumnType("varchar(100)");
            builder.Property(t => t.Numero).HasColumnType("varchar(50)");
        }
    }
}
