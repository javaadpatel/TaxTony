using TaxTony.Core.Enums;
using TaxTony.Core.Models.Base;

namespace TaxTony.Core.Models
{
    public class TaxCalculation : ModelBase
    {
        public decimal AnnualSalary { get; set; }
        public string PostalCode { get; set; }
        public TaxStrategy TaxStrategy { get; set; }
    }
}
