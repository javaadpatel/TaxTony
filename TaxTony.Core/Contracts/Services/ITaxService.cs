using System.Threading.Tasks;

namespace TaxTony.Core.Contracts.Services
{
    public interface ITaxService
    {
        Task<decimal> CalculateTaxAsync(Models.TaxCalculation taxCalculation);
    }
}
