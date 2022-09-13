
namespace DataAcess.Models
{
    public class Events
    {
        public int EventsId { get; set; }
        public string Name { get; set; }
        public string InstitutionName { get; set; }
        public string? Description { get; set; }
        public int QtdTicket { get; set; }
        //public int ProfileId { get; set; }
        public virtual Profiles ProfileId { get; set; }
        public ICollection<Tickets> tickets { get; set; }

    }
}
