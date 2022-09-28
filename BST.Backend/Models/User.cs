using System.Text.Json.Serialization;

namespace BST.Models
{
	public class User
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Hmd { get; set; } = string.Empty;
		public virtual ICollection<ScoreSaberUser> ScoreSaberUsers { get; set; } = null!;
		public virtual MapPool MapPool { get; set; } = null!;
		[JsonIgnore] public virtual Model Model { get; set; } = null!;
	}
}