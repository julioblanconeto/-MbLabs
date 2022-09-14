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

        //[HttpGet(Name = "Events")]
        //public async Task<List<EventsDto>> Get()
        //{
        //    return await eventsServices.GetAllEvents();
        //}

        [HttpGet(Name = "Events")]
        public IResult EventsFilter(int? filter)
        {
            return Results.Json(eventsServices.GetEvents(filter));
        }

        [HttpPost(Name = "NewEvent")]
        public  async Task<IResult> PostNewEevent([FromBody] NewEventDto newEvent)
        {
            return Results.StatusCode( await eventsServices.NewEvent(newEvent));
        }

    }
}
