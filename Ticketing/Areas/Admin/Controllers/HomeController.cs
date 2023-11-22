using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ticketing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var jsonData = JsonConvert.SerializeObject(new Person
            {
                Id = 1,
                Name = "Kiani"
            });
            ViewBag.Data = jsonData;
            return View();
        }
    }

}
