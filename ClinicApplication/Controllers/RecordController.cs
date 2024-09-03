using Microsoft.AspNetCore.Mvc;

namespace ClinicApplication.Controllers
{
    public class RecordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
