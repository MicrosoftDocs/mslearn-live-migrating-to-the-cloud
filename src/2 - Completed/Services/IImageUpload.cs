using System.IO;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	public interface IImageUpload
	{
		Task<string> StoreStream(string suggestedFilename, Stream stream);
	}
}
