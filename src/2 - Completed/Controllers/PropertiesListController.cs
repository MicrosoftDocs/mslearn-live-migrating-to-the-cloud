using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Services;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace RealEstate.Controllers
{
	[Route("properties")]
    public class PropertiesListController : Controller
    {
		public PropertiesListController(IDataRepository repo)
		{
			_repo = repo;
		}

		readonly IDataRepository _repo;

		[HttpGet("", Name = "GetProperties")]
		[HttpPost("", Name = "GetProperties")]
		public async Task<ActionResult> GetProperties(int? pageNumber, string searchString, string sortBy, bool? sortAscending)
		{
			if (pageNumber == null || pageNumber <= 0)
			{
				pageNumber = 1;
			}

			var properties = await _repo.GetProperties(searchString, sortBy, sortAscending ?? true);

			var vm = new PropertyListViewModel {
				CurrentPage = pageNumber.Value,
				SearchString = searchString,
				SortAscending = sortAscending ?? true,
				SortBy = sortBy
			};

			vm.Properties = properties
				.Select(p => p.ToViewModel())
				.ToPagedList(vm.CurrentPage, vm.ObjectsPerPage);

			ModelState.Clear();
			return View("List", vm);
		}
	}
}