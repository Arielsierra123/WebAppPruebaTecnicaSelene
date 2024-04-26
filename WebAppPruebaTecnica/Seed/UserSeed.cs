using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppPruebaTecnica.Entities;

namespace WebAppPruebaTecnica.Seed
{
    public class UserSeed: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id=1, Email = "admin@mail.com", Password = "123456789", RoleId=1, Name="Administrator" },
                new User { Id = 2, Email = "sale@mail.com", Password = "123456789", RoleId = 2, Name= "Sale" },
                new User { Id = 3, Email = "sale2@mail.com", Password = "123456789", RoleId = 2, Name = "Sale2" },
                new User { Id = 4, Email = "sale3@mail.com", Password = "123456789", RoleId = 2, Name = "Sale3" }
            );
        }
    }
}
