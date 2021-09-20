using Jarbas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jarbas.Domain.Configurations
{
    public class EmissionConfiguration : IEntityTypeConfiguration<Emission>
    {
        public void Configure(EntityTypeBuilder<Emission> orderConfiguration)
        {
            orderConfiguration.ToTable("Emission","jarbinhas");
        }
    }
}
