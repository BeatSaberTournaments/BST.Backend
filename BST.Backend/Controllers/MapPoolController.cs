using Microsoft.AspNetCore.Mvc;

namespace BST.Controllers
{
	[ApiController]
	public class MapPoolController
	{
		[HttpGet("/mappool")]
		public Task<ActionResult> GetAll()
		{
			return Task.FromResult<ActionResult>(new NotFoundResult());
		}
	}
}