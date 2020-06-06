using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaxTony.Core.Models;

namespace TaxTony.Web.ViewModels
{
    public class HomeViewModel
    {
        [Required]
        [Display(Name="Annual Salary")]
        [DataType(DataType.Currency)]
        public decimal AnnualSalary { get; set; }

        [Display(Name="Postal Code")]
        public List<SelectListItem> PostalCodes { get; set; }
    }
}
