using StronglyTypedIds;

namespace MyBudget.Core
{
    [StronglyTypedId(backingType: StronglyTypedIdBackingType.Guid, converters: StronglyTypedIdConverter.EfCoreValueConverter)]
    public partial struct CostCenterId { }
}
