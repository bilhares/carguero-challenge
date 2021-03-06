using AddressRegister.Domain.Entities;
using AddressRegister.Infra.Extensions;
using AddressRegister.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AddressRegister.Infra.Context
{
    public class AddressRegisterDbContext : DbContext
    {
        public AddressRegisterDbContext(DbContextOptions<AddressRegisterDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Username)
                .IsUnique();

            modelBuilder.AddConfiguration(new UserMapping());
            modelBuilder.AddConfiguration(new AddressMapping());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }
}
