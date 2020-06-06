using System.ComponentModel.DataAnnotations;
using TaxTony.Core.Enums;
using TaxTony.DataAccess.Entities.Base;

namespace TaxTony.DataAccess.Entities
{
    public class TaxCalculation : EntityBase
    {
        [Required]
        public decimal AnnualSalary { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(4)]
        public string PostalCode { get; set; }
        public TaxStrategy TaxStrategy { get; set; }
    }
}
