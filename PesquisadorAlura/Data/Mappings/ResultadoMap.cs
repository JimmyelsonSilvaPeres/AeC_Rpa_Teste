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
    public class ResultadoMap : IEntityTypeConfiguration<Resultado>
    {
        public void Configure(EntityTypeBuilder<Resultado> builder)
        {
            builder.ToTable("aec_resultado");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).HasColumnName("res_id").IsRequired();
            builder.Property(p => p.Descricao).HasColumnName("res_descricao").HasColumnType("nvarchar(255)");
            builder.Property(p => p.Titulo).HasColumnName("res_titulo").HasColumnType("nvarchar(255)");
            builder.Property(p => p.CargaHoraria).HasColumnName("res_carga_horaria").HasColumnType("INTEGER");
            builder.Property(p => p.ConsultaId).HasColumnName("res_con_id").HasColumnType("INTEGER");

            builder.HasMany(p => p.Professores)
                .WithMany(p => p.Resultados);
        }
    }
}
