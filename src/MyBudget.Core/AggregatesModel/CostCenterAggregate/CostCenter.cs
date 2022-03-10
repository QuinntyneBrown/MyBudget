using System;

namespace MyBudget.Core
{
    public class CostCenter
    {
        public CostCenterId CostCenterId { get; private set; }  = new CostCenterId(Guid.NewGuid());
        public string Name { get; private set; }
        public CostCenterCategory Category { get; private set; }
        public bool IsEssential { get; private set; }

        public CostCenter(string name, CostCenterCategory category, bool isEssential)
            :this(name, category)
        {
            IsEssential = isEssential;
        }

        public CostCenter(string name, CostCenterCategory category)
        {
            Name = name;
            Category = category;
        }

        public CostCenter()
        {

        }

    }
}
