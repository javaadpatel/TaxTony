using System.Threading.Tasks;
using TaxTony.Core.Contracts.Factories;
using TaxTony.Core.Contracts.Repositories;
using TaxTony.Core.Contracts.Services;

namespace TaxTony.Services.Services
{
    public class TaxService : ITaxService
    {
        #region Constructor and Fields
        private readonly ITaxStrategyFactory _taxStrategyFactory;
        private readonly ITaxCalculationRepository _taxCalculationRepository;

        public TaxService(
            ITaxStrategyFactory taxStrategyFactory, 
            ITaxCalculationRepository taxCalculationRepository)
        {
            _taxStrategyFactory = taxStrategyFactory ?? throw new System.ArgumentNullException(nameof(taxStrategyFactory));
            _taxCalculationRepository = taxCalculationRepository ?? throw new System.ArgumentNullException(nameof(taxCalculationRepository));
        }
        #endregion

        public async Task<decimal> CalculateTaxAsync(Core.Models.TaxCalculation taxCalculation)
        {
            var tax = _taxStrategyFactory
                        .CreateTaxStrategy(taxCalculation.TaxStrategy)
                        .CalculateTax(taxCalculation.AnnualSalary);

            await _taxCalculationRepository.CreateAsync(taxCalculation);
            return tax;
        }
    }
}
