
namespace DataAcess.Models
{
    public class Profiles
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public ICollection<Events> Events { get; set; }
    }
}
