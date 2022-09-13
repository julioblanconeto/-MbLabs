using DataAcess.Models;
using DataLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private EventsServives eventsServices;

        public EventsController()
        {
            eventsServices = new EventsServives();
        }

        [HttpGet(Name = "GetEvents")]
        public async Task<Events> Get()
        {
            return await eventsServices.GetAllEvents();
        }
    }
}
