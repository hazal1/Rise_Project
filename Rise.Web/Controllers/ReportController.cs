using Microsoft.AspNetCore.Mvc;

namespace Rise.Web.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
