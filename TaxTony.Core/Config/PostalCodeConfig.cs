using System.Collections.Generic;
using TaxTony.Core.Enums;
using TaxTony.Core.Models;

namespace TaxTony.Core.Config
{
    /// <summary>
    /// Configuration for the type of tax strategy that applies to Postal Code
    /// </summary>
    public static class PostalCodeConfig
    {
        public static IList<PostalCode> PostalCodes { get; } = new List<PostalCode>
        {
            new PostalCode
            {
                Code = "7441",
                TaxStrategy = TaxStrategy.PROGRESSIVE
            },
            new PostalCode
            {
                Code = "A100",
                TaxStrategy = TaxStrategy.FLATVALUE
            },
            new PostalCode
            {
                Code = "7000",
                TaxStrategy = TaxStrategy.FLATRATE
            },
            new PostalCode
            {
                Code = "1000",
                TaxStrategy = TaxStrategy.PROGRESSIVE
            }
        };
    }
}
