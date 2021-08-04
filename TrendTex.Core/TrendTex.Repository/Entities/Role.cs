using Microsoft.AspNetCore.Identity;

namespace TrendTex.Repository.Entities
{
	public class Role: IdentityRole
	{
		public string Name { get; set; }
	}
}
