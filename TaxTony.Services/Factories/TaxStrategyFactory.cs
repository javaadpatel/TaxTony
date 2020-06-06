using System;
using TaxTony.Core.Contracts.Factories;
using TaxTony.Core.Contracts.Services;
using TaxTony.Core.Enums;
using TaxTony.Services.Services.TaxStrategies;

namespace TaxTony.Services.Factories
{
    public class TaxStrategyFactory : ITaxStrategyFactory
    {
        public ITaxStrategy CreateTaxStrategy(TaxStrategy taxStrategy)
        {
            switch (taxStrategy)
            {
                case TaxStrategy.FLATRATE:
                    return new FlatRateTaxStrategy();
                case TaxStrategy.FLATVALUE:
                    return new FlatValueTaxStrategy();
                case TaxStrategy.PROGRESSIVE:
                    return new ProgressiveTaxStrategy();
                default:
                    throw new ArgumentException("TaxStrategy not found");
            }
        }
    }
}
