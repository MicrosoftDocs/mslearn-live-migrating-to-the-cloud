using System.IO;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	/// <summary>
	/// Abstraction for image uploads in the admin area of the project
	/// </summary>
	public interface IImageUpload
	{
		/// <summary>
		/// Reads the incoming <paramref name="imageStream"/> and persists it using <paramref name="filename"/>
		/// as the filename or identifier.
		/// </summary>
		/// <param name="filename">filename to use when persisting the stream</param>
		/// <param name="imageStream">stream that contains the data (image) to be saved</param>
		/// <returns>the full path or location of the persisted image</returns>
		Task<string> StoreImage(string filename, Stream imageStream);
	}
}
