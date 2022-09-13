
namespace DataAcess.Models
{
    public class Events
    {
        public int EventsId { get; set; }
        public string Name { get; set; }
        public string InstitutionName { get; set; }
        public string Description { get; set; }
        public int qtdTicket { get; set; }
        public virtual Profiles IdProfile { get; set; }

    }
}
