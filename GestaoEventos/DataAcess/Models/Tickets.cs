
namespace DataAcess.Models
{
    public class Tickets
    {
        public int TicketsId { get; set; }
        public int QtdTicket { get; set; }
        public DateTimeOffset PurchasedDate { get; set; }
        public  int EventsId { get; set; }
        public  int UserId { get; set; }
    }
}
