namespace RealEstate.Entities
{
	public class PropertyAsset
	{
		public int? Id { get; set; }
		// This is not strictly required because we have a reference to the Property anyway,
		// but when seeding data a weak foreign key reference must be specified.
		// To avoid delaing with anonymous types, I just added this.
		// Details: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
		public int PropertyId { get; set; }
		public Property Property { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}
