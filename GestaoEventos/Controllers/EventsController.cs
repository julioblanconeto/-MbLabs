using DataAcess.Dtos;
using DataAcess.Helpers;
using DataLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private EventsServives eventsServices;

        public EventsController(DataContext context)
        {
            eventsServices = new EventsServives(context);
        }

        [HttpGet(Name = "Events")]
        public async Task<List<EventsDto>> EventsFilter(int? filter)
        {
            return  await eventsServices.GetEvents(filter);
        }

        [HttpPost(Name = "NewEvent")]
        public  async Task<IResult> PostNewEevent([FromBody] NewEventDto newEvent)
        {
            return Results.StatusCode( await eventsServices.NewEvent(newEvent));
        }


        
    }
}
