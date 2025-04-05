using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Context.Configs
{
    public class EnderecoConfig : IEntityTypeConfiguration <Endereco> 
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Rua).IsRequired().HasMaxLength(30);
            builder.Property(c => c.Bairro).IsRequired().HasMaxLength(30);
            builder.Property(c => c.Cep).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Numero).IsRequired().HasMaxLength(5);
        }
    }
}
