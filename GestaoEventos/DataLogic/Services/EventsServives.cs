using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Services
{
    public class EventsServives
    {

        public async Task<Events> GetAllEvents()
        {
            Events  events = new Events();
            return events;
        }
    }
}
