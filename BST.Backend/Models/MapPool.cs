using System.Text.Json.Serialization;

namespace BST.Models
{
    public class MapPool
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public virtual ICollection<Map> Maps { get; set; } = null!;
        public DateTime SetDate { get; set; }
        [JsonIgnore] public virtual Model Model { get; set; } = null!;
        [JsonIgnore] public Guid ModelId { get; set; }
    }
}