using System.Threading.Tasks;
using TaxTony.Core.Contracts.Factories;
using TaxTony.Core.Contracts.Services;
using TaxTony.Core.Enums;

namespace TaxTony.Services.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxStrategyFactory _taxStrategyFactory;

        public TaxService(ITaxStrategyFactory taxStrategyFactory)
        {
            _taxStrategyFactory = taxStrategyFactory;
        }

        public async Task<decimal> CalculateTax(decimal annualSalary, TaxStrategy taxStrategy)
        {
            var tax = _taxStrategyFactory.CreateTaxStrategy(taxStrategy).CalculateTax(annualSalary);

            return tax;
        }
    }
}
