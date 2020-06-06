using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using TaxTony.Core.Contracts.Factories;
using TaxTony.Core.Contracts.Repositories;
using TaxTony.Core.Enums;
using TaxTony.Services.Services;
using TaxTony.Services.Services.TaxStrategies;
using Models = TaxTony.Core.Models;

namespace TaxTony.Services.Tests.Services
{
    [TestFixture]
    public class TaxServiceTests
    {
        #region Constructor and Fields
        private readonly TaxService _sut;
        private readonly Mock<ITaxStrategyFactory> _taxStrategyFactory;
        private readonly Mock<ITaxCalculationRepository> _taxCalculationRepository;
        private readonly Fixture _fixture;

        public TaxServiceTests()
        {
            _taxStrategyFactory = new Mock<ITaxStrategyFactory>().SetupAllProperties();
            _taxCalculationRepository = new Mock<ITaxCalculationRepository>().SetupAllProperties();
            _fixture = new Fixture();

            _sut = new TaxService(
                _taxStrategyFactory.Object,
                _taxCalculationRepository.Object
            );
        }
        #endregion

        #region Constructor Test
        [Test]
        public void Constructor_Should_Create_Instance()
        {
            var instance = new TaxService(
                _taxStrategyFactory.Object,
                _taxCalculationRepository.Object
            );
            instance.Should().NotBeNull("because an instance should be created");
        }
        #endregion

        #region CalculateTax
        [Test]
        public async Task CalculateTax_Should()
        {
            var taxCalculation = _fixture
                .Build<Models.TaxCalculation>()
                .With(t => t.PostalCode, "7000")
                .Create();

            _taxStrategyFactory.Setup(t => t.CreateTaxStrategy(It.IsAny<TaxStrategy>()))
                .Returns(new FlatRateTaxStrategy());

            var tax = await _sut.CalculateTaxAsync(taxCalculation);

            _taxCalculationRepository.Verify(tc => tc.CreateAsync(taxCalculation), Times.Once);
        }
        #endregion
    }
}
