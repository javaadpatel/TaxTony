using TaxTony.Core.Contracts.Services;

namespace TaxTony.Services.Services.TaxStrategies
{
    public class FlatValueTaxStrategy : ITaxStrategy
    {
        private decimal _annualSalaryThreshold = 200000m;
        private decimal _taxRate = 5m;
        private decimal _flatTaxAmount = 10000m;

        public decimal CalculateTax(decimal annualSalary)
        {
            if (annualSalary > _annualSalaryThreshold)
                return _flatTaxAmount;
            else
                return annualSalary * (_taxRate / 100m);
        }
    }
}
