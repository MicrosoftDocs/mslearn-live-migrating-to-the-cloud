using RealEstate.Entities;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RealEstate
{
	public static class RealEstateHelpers
	{
		public static string CombineUri(params string[] uriParts)
		{
			var uri = string.Empty;
			if (uriParts != null && uriParts.Length > 0)
			{
				var trims = new char[] { '\\', '/' };
				uri = (uriParts[0] ?? string.Empty).TrimEnd(trims);
				for (var i = 1; i < uriParts.Length; i++)
				{
					uri = string.Format("{0}/{1}", uri.TrimEnd(trims), (uriParts[i] ?? string.Empty).TrimStart(trims));
				}
			}
			return uri;
		}

		public static PropertyViewModel ToViewModel(this Property property, bool userIsAdmin = false) => new PropertyViewModel {
			Property = property,
			MainImageUrl = property.Assets?.FirstOrDefault()?.ImageUrl,
			IsUserAdmin = userIsAdmin
		};

		public static bool IsUserAdmin(ClaimsPrincipal user) => user != null && user.IsInRole("Administrator");

		internal static (List<Property> properties, List<PropertyAsset> assets) CreateProperties()
		{
			var properties = new List<Property>();
			var assets = new List<PropertyAsset>();

			Property prop = null;
			for (int propIndex = 1; propIndex <= 100; propIndex++)
			{
				prop = new Property {
					Name = "Property " + propIndex,
					NumberOfBathrooms = propIndex,
					NumberOfBedrooms = propIndex + 1,
					Id = propIndex,
					Price = propIndex * 10000,
					Description = "This is a beautiful property. Look at its ID of " + propIndex,
					LastUpdatedUtc = DateTimeOffset.UtcNow.AddDays(-propIndex),
					HasAirConditioning = propIndex % 2 == 0,
					HasBalcony = propIndex % 3 == 0,
					HasBroadband = propIndex % 5 == 0,
					HasFloorboards = propIndex % 7 == 0,
					HasRemoteGarage = propIndex % 13 == 0,
				};

				for (int assetIndex = 1; assetIndex <= 2; assetIndex++)
				{
					var asset = new PropertyAsset {
						Id = (propIndex - 1) * 2 + assetIndex,
						//Property = prop,
						PropertyId = prop.Id.Value,
						Description = $"Image {assetIndex} for property {propIndex}",
						ImageUrl = $"/assets/demopropertyimages/property-{propIndex % 8}.jpg"
					};
					assets.Add(asset);
				}

				properties.Add(prop);
			}

			return (properties, assets);
		}
	}
}