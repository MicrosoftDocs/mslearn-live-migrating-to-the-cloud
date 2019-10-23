using RealEstate.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	public interface IDataRepository
	{
		Task<List<Property>> GetFeaturedProperties();
		Task<Property> GetPropertyDetails(int propertyId);
		Task<List<Property>> GetProperties(string searchString, string sortByPropertyName, bool sortAscending);
		Task<Property> UpsertProperty(Property property);
		Task<Property> DeleteProperty(int id);
		
		/// <summary>
		/// This method is for Entitiy Framework. When getting an entity from the DB and another one with the same ID is
		/// written, EF will complain about tracking two items with the same ID. Use this method to prevent an item from being tracked.
		/// </summary>
		/// <param name="existingProperty"></param>
		void StopTracking(Property existingProperty);
	}
}
