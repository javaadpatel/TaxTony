using TaxTony.Core.Enums;
using TaxTony.DataAccess.Entities.Base;

namespace TaxTony.DataAccess.Entities
{
    public class TaxCalculation : EntityBase
    {
        public decimal AnnualSalary { get; set; }
        public TaxStrategy TaxStrategy { get; set; }
    }
}
