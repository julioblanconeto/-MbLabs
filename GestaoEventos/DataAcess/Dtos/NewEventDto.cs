using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Dtos
{
    public class NewEventDto
    {
        public string Name { get; set; }
        public string InstitutionName { get; set; }
        public string? Description { get; set; }
        public int QtdTicket { get; set; }
        public int ProfileId { get; set; }
    }
}
