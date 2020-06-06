using System;
using System.Collections.Generic;
using TaxTony.Core.Contracts.Services;

namespace TaxTony.Services.Services.TaxStrategies
{
    public class ProgressiveTaxStrategy : ITaxStrategy
    {
        #region Constructor and Fields
        private readonly ProgressiveTaxScale _progressiveTaxScale;
        public ProgressiveTaxStrategy()
        {
            _progressiveTaxScale = BuildProgressiveTaxScale();
        }
        #endregion

        public decimal CalculateTax(decimal annualSalary)
        {
            decimal effectiveTax = 0m;
            for (int taxScaleCounter = 0; taxScaleCounter < _progressiveTaxScale.TaxScales.Count; taxScaleCounter++)
            {
                var taxScale = _progressiveTaxScale.TaxScales[taxScaleCounter];
                if (annualSalary <= taxScale.To)
                {
                    effectiveTax += (annualSalary - taxScale.From) * (taxScale.TaxRate / 100m);
                    break;
                } 
                else
                {
                    effectiveTax += (taxScale.To - taxScale.From) * (taxScale.TaxRate / 100m);
                }
            }

            return effectiveTax;
        }

        #region Helpers
        public ProgressiveTaxScale BuildProgressiveTaxScale()
        {
            return new ProgressiveTaxScale
            {
                TaxScales = new List<TaxScale>
                {
                    new TaxScale
                    {
                        From = 0m,
                        To = 8350m,
                        TaxRate = 10m
                    },
                    new TaxScale
                    {
                        From = 8351m,
                        To = 33950m,
                        TaxRate = 15m
                    },
                    new TaxScale
                    {
                        From = 33951m,
                        To = 82250m,
                        TaxRate = 25m
                    },
                    new TaxScale
                    {
                        From = 82251m,
                        To = 171550m,
                        TaxRate = 28m
                    },
                    new TaxScale
                    {
                        From = 171551m,
                        To = 372950m,
                        TaxRate = 33m
                    },
                    new TaxScale
                    {
                        From = 372951m,
                        To = Decimal.MaxValue,
                        TaxRate = 35m
                    }
                }
            };
        }
        #endregion
    }

    public class ProgressiveTaxScale
    {
        public List<TaxScale> TaxScales { get; set; }
    }

    public class TaxScale
    {
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal TaxRate { get; set; }
    }
}
