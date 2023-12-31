﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult List()
        {
            var model = ticketService.GetAllTickets()?.ToTicketModelList();
            return View(model);
        }
        public IActionResult SectionTickets(int secId)
        {
            var model = ticketService.GetTicketsBySectionId(secId)?.ToTicketModelList();
            return View(model);
        }
        #region CreateTicket
        [HttpGet]
        public IActionResult CreateTicket()
        {
            var model = new ModifyTicketModel();
            model.Sections = sectionService.GetAllSections()?.ToSectionModelList();

            return View(model);
        }
        [HttpPost]
        public IActionResult CreateTicket(ModifyTicketModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ticketService.AddTicket(model.Title, model.Description, model.SectionId);

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
                Id = ticket.Id,
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
            var ticket = ticketService.GetTicketById(model.Id);
            if (ticket == null)
            {
                ModelState.AddModelError("", "invalid ticket");
                return View(model);
            }
            ticket.Title = model.Title;
            ticket.Description = model.Description;
            ticket.ModifyDate = DateTime.Now;
            var result = ticketService.UpdateTicket(ticket);
            if (result > 0)
            {
                AddSuccess("Ticket was updated successfully");
                return RedirectToAction(nameof(List));
            }
            else
            {
                ModelState.AddModelError("", "Error on updating. Please try again.");
                return View(model);
            }


        }
        #endregion


        #region Delete Ticket
        [HttpGet]
        public IActionResult DeleteTicket(int id)
        {
            //Authentication Authorization Accounting
            var ticket = ticketService.GetTicketById(id);
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
        public IActionResult DeleteTicket(DeleteTicketModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var ticket = ticketService.GetTicketById(model.Id);
            if (ticket == null)
            {
                ModelState.AddModelError("", "invalid ticket");
                return View(model);
            }
            var result = ticketService.DeleteTicket(ticket);
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
    }
}
