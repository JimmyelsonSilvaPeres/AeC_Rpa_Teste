using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("aec_professor");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).HasColumnName("pro_id").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("pro_nome").HasColumnType("nvarchar(255)");

            builder.HasMany(p => p.Resultados)
                .WithMany(p => p.Professores);
        }
    }
}
