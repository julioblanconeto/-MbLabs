using DataAcess.Dtos;
using DataAcess.Helpers;
using DataAcess.Models;

namespace DataLogic.Services
{
    public class EventsServives
    {
        private readonly DataContext _dtContext;

        public EventsServives(DataContext context)
        {
            _dtContext = context;
        }

        List<Events> events = new List<Events>();
        List<EventsDto> eventsDto = new List<EventsDto>();

        public async Task<List<EventsDto>> GetAllEvents()
        {
            try
            {
                events  = _dtContext.Events.ToList();

                foreach (var eventOne in events)
                {
                    eventsDto.Add(await FillEventDto(eventOne));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return eventsDto;
        }
        public async Task<List<EventsDto>> GetEvents(int? filter)
        {
            try
            {
                if (filter == null)
                {
                    events = _dtContext.Events.ToList();
                }
                else { 
                    events = _dtContext.Events.Where(x=>x.ProfileId == filter).ToList();
                }

                foreach (var eventOne in events)
                {
                    eventsDto.Add(await FillEventDto(eventOne));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return eventsDto;
        }
        public async Task<int> NewEvent(NewEventDto newEvent)
        {

            Events events = await FillEvent(newEvent);

            try
            {
                _dtContext.Events.Add(events);
                _dtContext.SaveChanges();
            }
            catch (Exception)
            {
                return 500;
            }
            
            return 200;
        }

        private async Task<EventsDto> FillEventDto(Events _event)
        {
            EventsDto eventdto = new EventsDto();
            eventdto.Profile = _dtContext.Profiles.Where(x => x.ProfileId == _event.ProfileId).Select(x => x.Name).First();
            eventdto.QtdTicket = _event.QtdTicket;
            eventdto.InstitutionName = _event.InstitutionName;
            eventdto.Description = _event.Description;
            eventdto.EventName = _event.Name;

            return eventdto;
        }

        private async Task<Events> FillEvent(NewEventDto newEvent)
        {
            Events events = new Events();
            events.Name = newEvent.Name;
            events.InstitutionName = newEvent.InstitutionName;
            events.Description = newEvent.Description;
            events.QtdTicket = newEvent.QtdTicket;
            events.ProfileId = newEvent.ProfileId;

            return events;
        }
    }
}
