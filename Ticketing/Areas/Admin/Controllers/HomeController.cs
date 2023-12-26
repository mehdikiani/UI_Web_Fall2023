using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ticketing.Core;
using Ticketing.Core.Entities;
using Ticketing.Data;

namespace Ticketing.Areas.Admin.Controllers
{
    [Area("Admin")]
    //  [DisableTestActionFilter]
    public class HomeController : BaseAdminController
    {
        public HomeController()
        {
                
        }
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
        [TypeFilter(typeof(TestActionFilterAttribute))]
        public IActionResult Test(string randomData)
        {
            ViewBag.RandomData = randomData;
            return View();
        }
    }

}
