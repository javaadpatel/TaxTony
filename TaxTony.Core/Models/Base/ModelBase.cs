using System;
using System.ComponentModel.DataAnnotations;

namespace TaxTony.Core.Models.Base
{
    public class ModelBase
    {
        [Required]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
