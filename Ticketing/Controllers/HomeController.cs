using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.Entities;
using Ticketing.Core.EntityMappings;
using Ticketing.Core.Models;
using Ticketing.Data;
using Ticketing.Services;

namespace Ticketing.Controllers
{
    public class HomeController :Controller
    {
        private readonly ILandingPageService landingPageService;

        public HomeController(ILandingPageService landingPageService)
        {
            this.landingPageService = landingPageService;
        }
        public async Task<IActionResult> Index()
        {
            var sections = (await landingPageService.LoadRandomSectionsAsync(2))?.ToLandingPageModellList();
            return View(sections);
        }
    }
}
