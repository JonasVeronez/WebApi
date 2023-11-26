using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_cvihm.Models;

namespace Sistema_cvihm.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsersModel>
    {
        public void Configure(EntityTypeBuilder<UsersModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
        }
    }
}
