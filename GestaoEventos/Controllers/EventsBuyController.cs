using DataAcess.Dtos;
using DataAcess.Helpers;
using DataAcess.Models;
using DataLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsBuyController : ControllerBase
    {
        private BuyerServices buyerServices;
        public EventsBuyController(DataContext context)
        {
            buyerServices = new BuyerServices(context);
        }
        [HttpPost(Name = "BuyTicket")]
        public async Task<List<Guid>> PostBuyTicket([FromBody] TicketDto newTicket)
        {

            return await buyerServices.BuyTicket(newTicket);
        }
    }
}
