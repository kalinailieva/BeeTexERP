using System;
using System.ComponentModel.DataAnnotations;

namespace TrendTex.Repository.Entities
{
	public class EntityBase
	{
		[Key]
		public string Id = Guid.NewGuid().ToString();
	}
}
