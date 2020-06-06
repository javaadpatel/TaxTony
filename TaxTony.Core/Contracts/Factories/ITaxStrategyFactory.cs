using TaxTony.Core.Contracts.Services;
using TaxTony.Core.Enums;

namespace TaxTony.Core.Contracts.Factories
{
    public interface ITaxStrategyFactory
    {
        ITaxStrategy CreateTaxStrategy(TaxStrategy taxStrategy);
    }
}
