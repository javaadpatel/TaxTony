using TaxTony.Core.Enums;

namespace TaxTony.Core.Models
{
    public class PostalCode
    {
        public string Code { get; set; }
        public TaxStrategy TaxStrategy { get; set; }
    }
}
