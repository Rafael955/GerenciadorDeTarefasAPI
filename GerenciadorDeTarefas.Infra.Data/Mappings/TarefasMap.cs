using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Infra.Data.Mappings
{
    public class TarefasMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TAREFA");

            builder.HasKey(x  => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasColumnName("TITULO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired();

            builder.Property(x => x.DataCriacao)
               .HasColumnName("DATA_CRIACAO")
               .IsRequired();

            builder.Property(x => x.DataConclusao)
              .HasColumnName("DATA_CONCLUSAO");

            builder.Property(x => x.Status)
                .HasColumnName("STATUS")
                .HasDefaultValue(StatusTarefa.Pendente)
                .IsRequired();

            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}
