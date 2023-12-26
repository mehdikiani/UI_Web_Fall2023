using Microsoft.AspNetCore.Mvc;
using Ticketing.Core;
using Ticketing.Core.Models;
using Ticketing.Data;
using Ticketing.Core.EntityMappings;
using Ticketing.Services;

namespace Ticketing.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class TicketController : BaseAdminController
    {
        private readonly ITicketService ticketService;
        private readonly ISectionService sectionService;

        public TicketController(
            ITicketService ticketService
            , ISectionService sectionService)
        {
            //ticketService = new TicketService();
            this.ticketService = ticketService;
            this.sectionService = sectionService;
        }
        public IActionResult Index() => RedirectToAction(nameof(List));

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = (await ticketService.GetAllTicketsAsync())?.ToTicketModelList();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> SectionTickets(int secId)
        {
            var model = (await ticketService.GetTicketsBySectionIdAsync(secId))?.ToTicketModelList();
            return View(model);
        }
        #region CreateTicket
        [HttpGet]
        public async Task<IActionResult> CreateTicket()
        {
            var model = new ModifyTicketModel();
            await PrepareModelAsync(model);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(ModifyTicketModel model)
        {

            if (!ModelState.IsValid)
            {
                await PrepareModelAsync(model);
                return View(model);
            }

            await ticketService.AddTicketAsync(model.Title, model.Description, model.SectionId);

            return RedirectToAction(nameof(List));
        }
        #endregion

        #region Update Ticket
        [HttpGet]
        public async Task<IActionResult> UpdateTicket(int id)
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
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                SectionId = ticket.SectionId
            };
            await PrepareModelAsync(model);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTicket(ModifyTicketModel model)
        {

            if (!ModelState.IsValid)
            {
              await  PrepareModelAsync(model);
                return View(model);
            }
            var ticket =await ticketService.GetTicketByIdAsync(model.Id);
            if (ticket == null)
            {
                ModelState.AddModelError("", "invalid ticket");
               await PrepareModelAsync(model);
                return View(model);
            }
            ticket.Title = model.Title;
            ticket.Description = model.Description;
            ticket.ModifyDate = DateTime.Now;
            var result =await ticketService.UpdateTicketAsync(ticket);
            if (result > 0)
            {
                AddSuccess("Ticket was updated successfully");
                return RedirectToAction(nameof(List));
            }
            else
            {
                ModelState.AddModelError("", "Error on updating. Please try again.");
               await PrepareModelAsync(model);
                return View(model);
            }


        }
        #endregion


        #region Delete Ticket
        [HttpGet]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            //Authentication Authorization Accounting
            var ticket =await ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            //throw new ArgumentException("Ticket not found");
            {
                AddError("Invalid Ticket");
                return RedirectToAction(nameof(List));
            }
            var model = new DeleteTicketModel
            {
                Id = ticket.Id,
                Title = ticket.Title
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTicket(DeleteTicketModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var ticket =await ticketService.GetTicketByIdAsync(model.Id);
            if (ticket == null)
            {
                ModelState.AddModelError("", "invalid ticket");
                return View(model);
            }
            var result =await ticketService.DeleteTicketAsync(ticket);
            if (result > 0)
            {
                AddSuccess("Ticket was deleted successfully");
                return RedirectToAction(nameof(List));
            }
            else
            {
                ModelState.AddModelError("", "Error on deleting. Please try again.");
                return View(model);
            }

        }
        #endregion

        private async Task PrepareModelAsync(ModifyTicketModel model)
        {
            model.Sections = (await sectionService.GetAllSectionsAsync())?.ToSectionModelList();
        }
    }
}
