using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TokenJWT.Entity.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(e => e.Id)
                    .HasName("PK__Roles__CAF00515FBE74653");

            builder.Property(e => e.Id).HasColumnName("Rol");
            builder.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
