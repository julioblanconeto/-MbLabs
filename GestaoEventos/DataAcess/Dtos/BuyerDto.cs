using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Dtos
{
    public class TicketDto
    {
        public int QtdTicket { get; set; }
        public int EventsId { get; set; }
        public int UserId { get; set; }
    }
}
