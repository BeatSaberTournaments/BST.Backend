using System.Text.Json.Serialization;

namespace BST.Models
{
    public class Map
    {
        public string Name { get; set; }
        public string BeatSaverId { get; set; }
        public string Image { get; set; }
        public string Mapper { get; set; }
        public int Length { get; set; }
        public int Bpm { get; set; }
        public string Difficulty { get; set; }
        [JsonIgnore] public Guid MapId { get; set; }
        [JsonIgnore] public virtual Model Model { get; set; } = null!;
    }
}