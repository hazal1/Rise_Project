using Microsoft.AspNetCore.Mvc;
using Rise.Web.Services;

namespace Rise.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly PersonContactApiService _personContactApiService;
        private readonly PersonApiService _personApiService;
        public ReportController(PersonContactApiService personContactApiService, PersonApiService personApiService)
        {
            _personContactApiService = personContactApiService;
            _personApiService = personApiService;
        }
     
        public async Task<IActionResult> ContactReport()
        {
            return View(await _personContactApiService.GetAllContactWithAllPerson());
        }
        public async Task<IActionResult> PersonReport()
        {
            return View(await _personApiService.GetPersonWithContact());
        }
    }
}
