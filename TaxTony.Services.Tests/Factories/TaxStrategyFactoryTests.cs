using FluentAssertions;
using NUnit.Framework;
using System;
using TaxTony.Core.Contracts.Services;
using TaxTony.Core.Enums;
using TaxTony.Services.Factories;
using TaxTony.Services.Services.TaxStrategies;

namespace TaxTony.Services.Tests.Factories
{
    [TestFixture]
    public class TaxStrategyFactoryTests
    {
        #region Constructor and Fields
        private readonly TaxStrategyFactory _sut;

        public TaxStrategyFactoryTests()
        {
            _sut = new TaxStrategyFactory();
        }
        #endregion

        #region Constructor Test
        [Test]
        public void Constructor_Should_Create_Instance()
        {
            var instance = new TaxStrategyFactory();
            instance.Should().NotBeNull("because an instance should be created");
        }
        #endregion

        #region CreateTaxStrategy
        [TestCase(TaxStrategy.FLATVALUE, ExpectedResult = typeof(FlatValueTaxStrategy))]
        [TestCase(TaxStrategy.FLATRATE, ExpectedResult = typeof(FlatRateTaxStrategy))]
        [TestCase(TaxStrategy.PROGRESSIVE, ExpectedResult = typeof(ProgressiveTaxStrategy))]
        public Type CreateTaxStrategy_Should_Return_TaxStrategy_Instance(TaxStrategy taxStrategyType)
        {
            ITaxStrategy taxStrategy = _sut.CreateTaxStrategy(taxStrategyType);
            return taxStrategy.GetType();
        }
        #endregion
    }
}
