using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaxTony.Services.Services.TaxStrategies;

namespace TaxTony.Services.Tests.TaxStrategies
{
    [TestFixture]
    public class FlatRateTaxStategyTests
    {
        #region Constructor and Fields
        private readonly FlatRateTaxStrategy _sut;

        public FlatRateTaxStategyTests()
        {
            _sut = new FlatRateTaxStrategy();
        }
        #endregion

        #region Constructor Test
        [Test]
        public void Constructor_Should_Create_Instance()
        {
            var instance = new FlatRateTaxStrategy();
            instance.Should().NotBeNull("because an instance should be created");
        }
        #endregion

        #region CalculateTax Method
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1000, ExpectedResult = 175)]
        [TestCase(100000, ExpectedResult = 17500)]
        [TestCase(8351, ExpectedResult = 1461.425)]
        public decimal CalculateTax_Should_Return_Correct_Tax(decimal annualSalary)
        {
            return _sut.CalculateTax(annualSalary);
        }
        #endregion

    }
}
