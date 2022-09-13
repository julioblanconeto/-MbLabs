
namespace DataAcess.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual Profiles IdProfile { get; set; }
    }
}
