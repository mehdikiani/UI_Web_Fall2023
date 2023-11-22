using Microsoft.AspNetCore.Mvc;
namespace Ticketing.Controllers
{
    public class HomeController :Controller
    {
        public IActionResult Index() => View();
    }
}
