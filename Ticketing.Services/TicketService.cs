﻿using Ticketing.Data;
using Ticketing.Core.Models;
using Ticketing.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ticketing.Services
{
    public class TicketService : ITicketService
    {
       
        private readonly ILogSerivce logSerivce;
        private readonly IRepository<Ticket> ticketRepository;

        //private readonly ITicketRepository ticketRepository;

        public TicketService(
             ILogSerivce logSerivce
            //,ITicketRepository ticketRepository)
            ,IRepository<Ticket> ticketRepository
            , CancellationToken cancellationToken = default)
        {
            this.logSerivce = logSerivce;
            this.ticketRepository = ticketRepository;
            //this.ticketRepository = ticketRepository;
        }

        public Ticket AddTicket(string title, string description, int sectionId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));
            // return Tickets.AddTicket(title, description);   
            var now = DateTime.Now;
            var ticket = new Ticket
            {
                Title = title,
                Description = description,
                Status = TicketStatus.New,
                CreateDate = now,
                ModifyDate = now,
                Deleted = false,
                SectionId = sectionId
            };
            ticketRepository.Insert(ticket);
            return ticket;
        }

        public int DeleteTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            // db.Tickets.Remove(ticket);
            ticket.Deleted = true;
            ticket.ModifyDate = DateTime.Now;
            return ticketRepository.Update(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return ticketRepository.GetAll()
                .Where(p => !p.Deleted)
                .Include(p => p.Section)
                .ToList();

        }
        public List<Ticket> GetTicketsBySectionId(int sectionId)
        {
            return ticketRepository.GetAll()
                .Where(p => !p.Deleted && p.SectionId == sectionId)
                .Include(p => p.Section)
                .ToList();

        }
        public Ticket GetTicketById(int id)
        {
            return ticketRepository.GetAll()
                .FirstOrDefault(p => p.Id == id && !p.Deleted);
            //return db.Tickets.Find(id);
        }

        public int UpdateTicket(Ticket ticket)
        {
            //Tacking Chaange
            var result = ticketRepository.Update(ticket);
            if (result > 0)
            {
                logSerivce.LogInfo($"The ticket {ticket.Title} was updatd at {DateTime.Now}");
            }
            return result;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync(CancellationToken cancellationToken = default)
        {
            return await ticketRepository.GetAll()
                .Where(p => !p.Deleted)
                .Include(p => p.Section)
                .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsBySectionIdAsync(int sectionId, CancellationToken cancellationToken = default)
        {
            return await ticketRepository.GetAll()
                  .Where(p => !p.Deleted && p.SectionId == sectionId)
                  .Include(p => p.Section)
                  .ToListAsync();
        }

        public async Task<Ticket> AddTicketAsync(string title, string description, int sectionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));
            // return Tickets.AddTicket(title, description);   
            var now = DateTime.Now;
            var ticket = new Ticket
            {
                Title = title,
                Description = description,
                Status = TicketStatus.New,
                CreateDate = now,
                ModifyDate = now,
                Deleted = false,
                SectionId = sectionId
            };
           await ticketRepository.InsertAsync(ticket);
            return ticket;
        }

        public async Task<Ticket> GetTicketByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await ticketRepository.GetAll()
               .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);
        }

        public async Task<int> UpdateTicketAsync(Ticket ticket, CancellationToken cancellationToken = default)
        {
            var result =await ticketRepository.UpdateAsync(ticket);
            if (result > 0)
            {
                logSerivce.LogInfo($"The ticket {ticket.Title} was updatd at {DateTime.Now}");
            }
            return result;
        }

        public async Task<int> DeleteTicketAsync(Ticket ticket, CancellationToken cancellationToken = default)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            // db.Tickets.Remove(ticket);
            ticket.Deleted = true;
            ticket.ModifyDate = DateTime.Now;
            return await ticketRepository.UpdateAsync(ticket);
        }
    }
}
