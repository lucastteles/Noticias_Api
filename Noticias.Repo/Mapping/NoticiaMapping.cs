using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noticias.Domain.Entidade;


namespace Noticias.Repo.Mapping
{
    public class NoticiaMapping : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.ToTable("Noticia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
              .HasColumnName("Titulo")
              .HasMaxLength(50)
              .IsRequired();


            builder.Property(x => x.Conteudo)
              .HasColumnName("Conteudo")
              .IsRequired();


            builder.Property(x => x.Categoria)
              .HasColumnName("Categoria")
              .IsRequired();


            builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro");

        }
    }
}
