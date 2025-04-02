using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Context.Configs
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);
            //Lambda
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Sobrenome).IsRequired().HasMaxLength(50);
            builder.Property(c => c.DataNascimento).HasColumnType("Date");
            builder.Property(c => c.Cpf).IsRequired().HasMaxLength(14);
            builder.Property(c => c.Email).HasMaxLength(50);
        }
    }
}
