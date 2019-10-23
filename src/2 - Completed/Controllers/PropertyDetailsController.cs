using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Controllers
{
	[Route("properties")]
	public class PropertyDetailsController : Controller
    {
        public PropertyDetailsController(IDataRepository repo)
		{
			_repo = repo;
		}

		readonly IDataRepository _repo;

		[HttpGet("{propertyId}", Name = "ShowPropertyFullDetails")]
        public async Task<IActionResult> ShowPropertyFullDetails(int propertyId)
        {
			var propertyDetails = await _repo.GetPropertyDetails(propertyId);

			var vm = propertyDetails.ToViewModel(RealEstateHelpers.IsUserAdmin(User));

			return View("Details", vm);
        }
	}
}
