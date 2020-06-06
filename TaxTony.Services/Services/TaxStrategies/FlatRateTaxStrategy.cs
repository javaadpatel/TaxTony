using TaxTony.Core.Contracts.Services;

namespace TaxTony.Services.Services.TaxStrategies
{
    public class FlatRateTaxStrategy : ITaxStrategy
    {                
        private decimal _taxRate = 17.5m;

        public decimal CalculateTax(decimal annualSalary)
        {
            return annualSalary * (_taxRate / 100m);
        }
    }
}
