using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.Entities;
using Ticketing.Core.EntityMappings;
using Ticketing.Core.Models;
using Ticketing.Data;

namespace Ticketing.Controllers
{
    public class HomeController :Controller
    {
        private readonly IRepository<LandingPage> _repository;
        public HomeController(IRepository<LandingPage> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            List<LandingPageModel> landingPageRows = _repository.GetAll().ToList().ToLandingPageModellList();
           
            return View(landingPageRows);
        }
    }
}
