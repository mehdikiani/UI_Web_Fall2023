
using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.Entities;
using Ticketing.Core.EntityMappings;
using Ticketing.Core.Models;
using Ticketing.Data;
using Ticketing.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Ticketing.Controllers
{

    public class HomeController : Controller
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {

            await SignInAsync(new SigninModel(1,"mkiani","Mehdi","Kiani")); 
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        public async Task<IActionResult> Logout()
        {
            await SignoutAsync();
            return RedirectToAction("Index");
        }

        private async Task SignInAsync(SigninModel signinModel)
        {

            if (signinModel == null)
                throw new ArgumentNullException(nameof(signinModel));

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,signinModel.UserId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.GivenName,signinModel.Username));
            identity.AddClaim(new Claim(ClaimTypes.Name,signinModel.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname,signinModel.LastName));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
            {
                IsPersistent = signinModel.IsPersist
            });
            return;
        }

        private async Task SignoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
