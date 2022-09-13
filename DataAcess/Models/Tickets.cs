
namespace DataAcess.Models
{
    public class Tickets
    {
        public int TicketsId { get; set; }
        public virtual Events EventsId { get; set; }
        public virtual Users UserId { get; set; }
        public DateTimeOffset PurchasedDate { get; set; }
    }
}
