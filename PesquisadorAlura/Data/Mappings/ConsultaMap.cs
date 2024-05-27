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
    public class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("aec_consulta");
            builder.Property(c => c.Id).HasColumnName("con_id").IsRequired();
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TextoConsultado).HasColumnName("con_texto_consulta");
        }
    }
}
