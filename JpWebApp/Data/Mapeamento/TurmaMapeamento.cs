using JpWebApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JpWebApp.Data.Mapeamento
{
    public class TurmaMapeamento : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnType("varchar(50)");
            builder.Property(t => t.DataInicio).HasColumnType("date");
            builder.Property(t => t.DataFim).HasColumnType("date");
        }

    }
}
