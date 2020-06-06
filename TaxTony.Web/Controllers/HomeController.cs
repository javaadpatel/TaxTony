using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TaxTony.Core.Config;
using TaxTony.Core.Contracts.Services;
using TaxTony.Web.Models;
using TaxTony.Web.ViewModels;

namespace TaxTony.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaxService _taxService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITaxService taxService, ILogger<HomeController> logger)
        {
            _taxService = taxService ?? throw new System.ArgumentNullException(nameof(taxService));
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                PostalCodes = PostalCodeConfig.PostalCodes.Select(p => new SelectListItem
                {
                    Value = p.Code,
                    Text = p.Code
                }).ToList()
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<JsonResult> CalculateTax(string annualSalary, string postalCode)
        {
            var postalCodeModel = PostalCodeConfig.PostalCodes.FirstOrDefault(p => p.Code == postalCode);
            return Json(await _taxService.CalculateTaxAsync(
                new Core.Models.TaxCalculation(
                    decimal.Parse(annualSalary), 
                    postalCodeModel.Code,
                    postalCodeModel.TaxStrategy)
            ));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
