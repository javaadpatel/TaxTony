using System.Threading.Tasks;
using TaxTony.Core.Enums;

namespace TaxTony.Core.Contracts.Services
{
    public interface ITaxService
    {
        Task<decimal> CalculateTax(decimal annualSalary, TaxStrategy taxStrategy);
    }
}
