using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace TrendTex.Repository.Entities
{
	public class User: IdentityUser<string>
    {
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        //[Required]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        public virtual Address Address { get; set; }
        public string AddressId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
