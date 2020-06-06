using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaxTony.Services.Services.TaxStrategies;

namespace TaxTony.Services.Tests.TaxStrategies
{
    [TestFixture]
    public class ProgressiveTaxStrategyTests
    {
        #region Constructor and Fields
        private readonly ProgressiveTaxStrategy _sut;

        public ProgressiveTaxStrategyTests()
        {
            _sut = new ProgressiveTaxStrategy();
        }
        #endregion

        #region Constructor Test
        [Test]
        public void Constructor_Should_Create_Instance()
        {
            var instance = new ProgressiveTaxStrategy();
            instance.Should().NotBeNull("because an instance should be created");
        }
        #endregion

        #region CalculateTax Method
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(8000, ExpectedResult = 800)]
        [TestCase(34000, ExpectedResult = 4687.1)]
        [TestCase(400000, ExpectedResult = 117682.14)]
        public decimal CalculateTax_Should_Return_Correct_Tax(decimal annualSalary)
        {
            return _sut.CalculateTax(annualSalary);
        }
        #endregion
    }
}
