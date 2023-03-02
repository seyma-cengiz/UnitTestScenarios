using Microsoft.AspNetCore.Mvc;

namespace UnitTestScenarios.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
