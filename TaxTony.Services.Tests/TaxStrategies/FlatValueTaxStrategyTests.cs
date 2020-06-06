using FluentAssertions;
using NUnit.Framework;
using TaxTony.Services.Services.TaxStrategies;

namespace TaxTony.Services.Tests.TaxStrategies
{
    [TestFixture]
    public class FlatValueTaxStrategyTests
    {
        #region Constructor and Fields
        private readonly FlatValueTaxStrategy _sut;

        public FlatValueTaxStrategyTests()
        {
            _sut = new FlatValueTaxStrategy();
        }
        #endregion

        #region Constructor Test
        [Test]
        public void Constructor_Should_Create_Instance()
        {
            var instance = new FlatValueTaxStrategy();
            instance.Should().NotBeNull("because an instance should be created");
        }
        #endregion

        #region CalculateTax Method
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1000, ExpectedResult = 50)]
        [TestCase(115.5, ExpectedResult = 5.775)]
        [TestCase(200000, ExpectedResult = 10000, TestName = "Annual Salary Threshold Test (Upper Boundary)")]
        [TestCase(199999, ExpectedResult = 9999.95, TestName = "Annual Salary Threshold Test (Lower Boundary)")]
        public decimal CalculateTax_Should_Return_Correct_Tax(decimal annualSalary)
        {
            return _sut.CalculateTax(annualSalary);
        }
        #endregion
    }
}
