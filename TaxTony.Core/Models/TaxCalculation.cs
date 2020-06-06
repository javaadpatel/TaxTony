using TaxTony.Core.Enums;
using TaxTony.Core.Models.Base;

namespace TaxTony.Core.Models
{
    public class TaxCalculation : ModelBase
    {
        public TaxCalculation(decimal annualSalary, string postalCode, TaxStrategy taxStrategy)
        {
            AnnualSalary = annualSalary;
            PostalCode = postalCode;
            TaxStrategy = taxStrategy;
        }
        public decimal AnnualSalary { get; set; }
        public string PostalCode { get; set; }
        public TaxStrategy TaxStrategy { get; set; }
    }
}
