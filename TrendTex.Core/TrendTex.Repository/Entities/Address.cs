namespace TrendTex.Repository.Entities
{
	public class Address: TrackableEntityBase
	{
		public string Country { get; set; }
		public string City { get; set; }
		public string AddressLine { get; set; }
	}
}