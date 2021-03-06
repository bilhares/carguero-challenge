using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressRegister.Infra.Mapping
{
    class AddressMapping : EntityTypeConfiguration<Address>
    {
        public override void Map(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Id);

            builder.Property(x => x.ZipCode)
             .IsRequired()
             .HasMaxLength(9);

            builder.Property(x => x.Number)
             .IsRequired();

            builder.Property(x => x.City)
             .IsRequired();

            builder.Property(x => x.District)
             .IsRequired();

            builder.Property(x => x.Complement)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(x => x.State)
             .IsRequired();

            builder.HasOne(x => x.User);

            builder.ToTable(nameof(Address));

        }
    }
}
