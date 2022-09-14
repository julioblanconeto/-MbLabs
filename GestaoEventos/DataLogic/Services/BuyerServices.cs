using DataAcess.Dtos;
using DataAcess.Helpers;
using DataAcess.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Services
{
    public class BuyerServices
    {
        private readonly DataContext _dtContext;

        public BuyerServices(DataContext context)
        {
            _dtContext = context;
        }

        public async Task<List<Guid>> BuyTicket(TicketDto newTicket)
        {

            Events events = new Events();
            List<Guid> tickets = new List<Guid>();


            IQueryable<Events> eventsResult = _dtContext.Events.Where(x => x.EventsId == newTicket.EventsId);

            var quantidade = eventsResult.Select(x => x.QtdTicket).First();
            if (quantidade == 0)
            {
                tickets.DefaultIfEmpty();
            }
            else
            {
                events = eventsResult.First();
                var qtdRestante = events.QtdTicket - newTicket.QtdTicket;

                if (qtdRestante > 0)
                {
                    events.QtdTicket = qtdRestante;
                    qtdRestante = newTicket.QtdTicket;
                }
                else
                {
                    qtdRestante = newTicket.QtdTicket + qtdRestante;
                    events.QtdTicket = 0;
                }

                var ticket = await FillTicket(newTicket);

                try
                {
                    _dtContext.Tickets.Add(ticket);
                    _dtContext.Events.Update(events);
                    _dtContext.SaveChanges();
                }
                catch (Exception)
                {
                    tickets.DefaultIfEmpty();
                }

                tickets = await GenerateTikcket(qtdRestante);

            }
            return tickets;

        }
        private async Task<List<Guid>> GenerateTikcket(int quantidade)
        {
            List<Guid> tickets = new List<Guid>();
            for (int i = 0; i < quantidade; i++)
            {
                tickets.Add(Guid.NewGuid());
            }
            return tickets;
        }
        private async Task<Tickets> FillTicket(TicketDto newTicket)
        {
            Tickets ticket = new Tickets();

            ticket.QtdTicket = newTicket.QtdTicket;
            ticket.UserId = newTicket.UserId;
            ticket.EventsId = newTicket.EventsId;
            ticket.PurchasedDate = DateTimeOffset.Now;

            return ticket;
        }
    }
}
