using Microsoft.EntityFrameworkCore;
using Ticketing.Data;
using Ticketing.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;
services.AddRazorPages();
services.AddDbContext<TicketDbContext>(
    options =>
    {
        options.UseSqlServer(config.GetConnectionString("TicketConn"));
    }
    );

//services.AddTransient<ITicketRepository, TicketRepository>();

services.AddTransient(typeof(IRepository<>),typeof(Repository<>));

services.AddTransient<ITicketService, TicketService>();
services.AddTransient<ISectionService, SectionService>();
services.AddTransient<ILogSerivce, LogService>();
services.AddTransient<ILandingPageService, LandingPageService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(ep =>
{
    //ep.MapDefaultControllerRoute();
    ep.MapControllerRoute("Areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    ep.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
