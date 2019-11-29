using RealEstate.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	public class MockDataRepository : IDataRepository
	{
		public MockDataRepository()
		{
		}

		public Task<List<Property>> GetFeaturedProperties()
		{

			return Task.FromResult(new List<Property> {
				new Property {
					Description = "Mock Property - no database available",
					Id = 1,
					Name = "Mock Property"
				}
			});
		}

		public Task<Property> GetPropertyDetails(int propertyId)
		{
			return Task.FromResult(new Property {
				Description = "Mock Property - no database available",
				Id = 1,
				Name = "Mock Property"
			});
		}

		public Task<List<Property>> GetProperties(string searchString, string sortByPropertyName, bool sortAscending)
		{
			return Task.FromResult(new List<Property> {
				new Property {
					Description = "Mock Property - no database available",
					Id = 1,
					Name = "Mock Property"
				}
			});
		}

		public Task<Property> UpsertProperty(Property property)
		{
			return Task.FromResult(property);
		}

		public Task<Property> DeleteProperty(int id)
		{
			return Task.FromResult<Property>(null);
		}

		public void StopTracking(Property existingProperty)
		{
		}

		public void RunMigration()
		{ }
	}
}
