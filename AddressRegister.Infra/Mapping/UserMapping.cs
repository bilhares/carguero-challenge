using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressRegister.Infra.Mapping
{
    class UserMapping : EntityTypeConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(120);

            builder.ToTable(nameof(User));
        }
    }
}
