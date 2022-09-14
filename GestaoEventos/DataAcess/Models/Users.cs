
namespace DataAcess.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        //public int ProfileId { get; set; }
        public int ProfileId { get; set; }

        public ICollection<Tickets> tickets { get; set; }
    }
}
