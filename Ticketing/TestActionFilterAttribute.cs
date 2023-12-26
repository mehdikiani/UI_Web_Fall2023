using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Ticketing.Services;

namespace Ticketing
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestActionFilterAttribute
        : ActionFilterAttribute
    {
        private readonly IRandomDataService randomDataService;

        public TestActionFilterAttribute(
            IRandomDataService randomDataService)
        {
            this.randomDataService = randomDataService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Filters.OfType<DisableTestActionFilterAttribute>()
                .Any())
                return;
            context.ActionArguments["randomData"] = randomDataService.GetRandomString();
            //context.Result =
            //    new RedirectToActionResult("Test", "Home", new
            //    {
            //        area = "Admin"
            //    });
            base.OnActionExecuting(context);
        }
    }
}
