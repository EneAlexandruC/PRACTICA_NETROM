using ShowTime.Enum;

namespace ShowTime.Entities
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Genre Genre { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public ICollection<Festival> Festivals { get; set; } = [];

    }
}
