using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressRegister.Infra.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
