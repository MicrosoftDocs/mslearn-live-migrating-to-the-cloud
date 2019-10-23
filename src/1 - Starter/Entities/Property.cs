using System;
using System.Collections.Generic;

namespace RealEstate.Entities
{
	public class Property
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public int NumberOfBathrooms { get; set; }
		public int NumberOfBedrooms { get; set; }
		public DateTimeOffset LastUpdatedUtc { get; set; }
		public bool HasAirConditioning { get; set; }
		public bool HasBroadband { get; set; }
		public bool HasBalcony { get; set; }
		public bool HasRemoteGarage { get; set; }
		public bool HasFloorboards { get; set; }
		public List<PropertyAsset> Assets { get; set; }
	}
}
