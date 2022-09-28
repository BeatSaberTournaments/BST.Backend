using System.Text.Json.Serialization;

namespace BST.Models
{
	public class ScoreSaberUser
	{
		public Guid Id { get; set; }
		public int ScoreSaberId { get; set; } = 0;
		public string Name { get; set; } = string.Empty;
		[JsonIgnore] public virtual Model Model { get; set; } = null!;
	}
}