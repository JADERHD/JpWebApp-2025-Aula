using JpWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JpWebApp.Data.Mapeamento
{
    public class ProfessorMapeamento : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Disciplina).HasColumnType("varchar(50)");
            builder.Property(t => t.NomeCompleto).HasColumnType("varchar(100)");
            builder.Property(t => t.Email).HasColumnType("varchar(50)");
        }
    }
}
