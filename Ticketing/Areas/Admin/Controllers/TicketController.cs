using Microsoft.AspNetCore.Mvc;
using Ticketing.Core;
using Ticketing.Core.Models;
using Ticketing.Data;
using Ticketing.Core.Models;
using Ticketing.Services;

namespace Ticketing.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class TicketController : BaseAdminController
    {
        private readonly ITicketService ticketService;

        public TicketController(
            ITicketService ticketService)
        {
            //ticketService = new TicketService();
            this.ticketService = ticketService;
        }
        public IActionResult Index() => RedirectToAction(nameof(List));
        public IActionResult List()
        {
            var model = ticketService.GetAllTickets();
            return View(model);
        }

        #region CreateTicket
        [HttpGet]
        public IActionResult CreateTicket()
        {
            return View(new ModifyTicketModel());
        }
        [HttpPost]
        public IActionResult CreateTicket(ModifyTicketModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ticketService.AddTicket(model.Title, model.Description);
           
            return RedirectToAction(nameof(List));
        }
        #endregion

        #region Update Ticket
        [HttpGet]
        public IActionResult UpdateTicket(int id)
        {
            //Authentication Authorization Accounting
            var ticket = ticketService.GetTicketById(id);
            if (ticket == null)
            //throw new ArgumentException("Ticket not found");
            {
                AddError("Invalid Ticket");
                return RedirectToAction(nameof(List));
            }
            var model = new ModifyTicketModel
            {
                TId = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateTicket(ModifyTicketModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var ticket = ticketService.GetTicketById(model.TId);
            if (ticket == null)
            {
                ModelState.AddModelError("", "invalid ticket");
                return View(model);
            }
            ticketService.UpdateTicket(model.TId, model.Title, model.Description);
            return RedirectToAction(nameof(List));
        }
        #endregion


    }
}
