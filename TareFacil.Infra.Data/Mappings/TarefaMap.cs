

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareFacil.Domain.Entities;

namespace TareFacil.Infra.Data.Mappings {
    public class TarefaMap : IEntityTypeConfiguration<Tarefa> {
        public void Configure(EntityTypeBuilder<Tarefa> builder) {


            builder.ToTable("TAREFAS");

            builder.HasKey("Id");

            builder.Property(t => t.Id).HasColumnName("ID");

            builder.Property(t => t.Titulo).HasColumnName("TITULO").HasMaxLength(150).IsRequired();

            builder.Property(t => t.Descricao).HasColumnName("DESCRICAO").HasMaxLength(255).IsRequired();

            builder.Property(t => t.DataCriacao).HasColumnName("DATACRIACAO").IsRequired();

            builder.Property(t => t.DataConclusao).HasColumnName("DATACONCLUSAO");

            builder.Property(t => t.Status).HasColumnName("STATUS").IsRequired();

        }
    }
}
