using System.Linq;
using RealEstate.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	public class MockDataRepository : IDataRepository
	{
		public MockDataRepository()
		{
			allProperties.AddRange(new [] { mockProperty, mockProperty2 });
		}

		List<Property> allProperties = new List<Property>();

		Property mockProperty = new Property {
					Description = "Mock Property",
					Id = 1,
					Name = "Mock Property",
					Price = 600000,
					NumberOfBathrooms = 1,
					NumberOfBedrooms = 4,
					Assets = new List<PropertyAsset>()
					{
						new PropertyAsset() { Id = 1, PropertyId = 1, Description = "Main Image", ImageUrl = "/assets/demopropertyimages/property-1.jpg" }
					}
				};
		Property mockProperty2 = new Property {
					Description = "Mock Property #2",
					Id = 2,
					Name = "Mock Property #2",
					Price = 520000,
					NumberOfBathrooms = 1,
					NumberOfBedrooms = 3,
					Assets = new List<PropertyAsset>()
					{
						new PropertyAsset() { Id = 3, PropertyId = 2, Description = "Main Image", ImageUrl = "/assets/demopropertyimages/property-2.jpg" }
					}
				};		

		public Task<List<Property>> GetFeaturedProperties()
		{
			return Task.FromResult(allProperties);
		}

		Property FromId(int propertyId)
		{
			return allProperties.FirstOrDefault(p => p.Id == propertyId);
		}

		public Task<Property> GetPropertyDetails(int propertyId)
		{
			return Task.FromResult(FromId(propertyId));
		}

		public Task<List<Property>> GetProperties(string searchString, string sortByPropertyName, bool sortAscending)
		{
			var properties = allProperties;

			if (!string.IsNullOrEmpty(searchString))
			{
				properties = properties.Where(p => p.Description.Contains(searchString) || p.Name.Contains(searchString)).ToList();
			}	

			switch (sortByPropertyName)
			{
				case "LastUpdatedUtc":
					properties = sortAscending ? 
						properties.OrderBy(p => p.LastUpdatedUtc).ToList() : properties.OrderByDescending(p => p.LastUpdatedUtc).ToList();
					break;
				case "Name":
					properties = sortAscending ? 
						properties.OrderBy(p => p.Name).ToList() : properties.OrderByDescending(p => p.Name).ToList();
					break;
				case "Price":
					properties = sortAscending ? 
						properties.OrderBy(p => p.Price).ToList() : properties.OrderByDescending(p => p.Price).ToList();
					break;
				default:
					properties = sortAscending ? 
						properties.OrderBy(p => p.Id).ToList() : properties.OrderByDescending(p => p.Id).ToList();
					break;
			}

			return Task.FromResult(properties);
		}

		public Task<Property> UpsertProperty(Property property)
		{
			if (!allProperties.Contains(property))
			{
				int? maxId = 0;
				if (allProperties.Count > 0)
				{
					maxId = allProperties.Max(p => p.Id);
					property.Id = maxId.Value + 1;
				}

				allProperties.Add(property);
			}

			return Task.FromResult(property);
		}

		public Task<Property> DeleteProperty(int id)
		{
			var property = allProperties.FirstOrDefault(p => p.Id == id);
			if (property != null)
			{
				allProperties.Remove(property);
			}

			return Task.FromResult<Property>(null);
		}

		public void StopTracking(Property existingProperty)
		{

		}

		public void RunMigration()
		{
			
		}
	}
}
