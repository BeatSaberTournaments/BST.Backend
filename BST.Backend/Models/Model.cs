using System.Text.Json.Serialization;

namespace BST.Models
{
    public class Model
    {
        public Guid Id { get; set; }
        [JsonIgnore] public virtual ICollection<Map> Maps { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<MapPool> MapPools { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<User> Users { get; set; } = null!;
    }
}