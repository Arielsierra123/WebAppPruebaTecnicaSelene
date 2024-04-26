using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppPruebaTecnica.Entities;

namespace WebAppPruebaTecnica.Seed
{
    public class RoleSeed: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role { Id=1, Name = "Admin"},
                new Role { Id=2, Name = "Sale" }
            );
        }
    }
}
