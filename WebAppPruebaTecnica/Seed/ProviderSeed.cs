using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAppPruebaTecnica.Entities;

namespace WebAppPruebaTecnica.Seed
{
    public class ProviderSeed : IEntityTypeConfiguration<Provider>
    {
            public void Configure(EntityTypeBuilder<Provider> builder)
            {
                builder.HasData(
                    new Provider { Id = 1, Name = "Telas", Nit="10778668996-1", Email="test@gmail.com", Phone=3103105 },
                    new Provider { Id = 2, Name = "D1", Nit = "10778668996-2", Email = "test2@gmail.com", Phone = 876945230 }
                );
            }
    }
}
