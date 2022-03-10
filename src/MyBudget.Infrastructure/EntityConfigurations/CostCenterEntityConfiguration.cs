using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Core;

namespace MyBudget.Infrastructure.EntityConfigurations
{
    public class CostCenterConfiguration : IEntityTypeConfiguration<CostCenter>
    {
        public void Configure(EntityTypeBuilder<CostCenter> builder)
        {
            builder.Property(e => e.CostCenterId).HasConversion(new CostCenterId.EfCoreValueConverter());
        }
    }
}
