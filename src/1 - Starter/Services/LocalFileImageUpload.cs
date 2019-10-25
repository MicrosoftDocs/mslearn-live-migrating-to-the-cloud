using System.IO;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	/// <summary>
	/// Implementation of IImageUpload which saves images locally on the webserver in a folder.
	/// </summary>
	public class LocalFileImageUpload : IImageUpload
	{
		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		/// <param name="localImagePath">full path where images will be saved to</param>
		/// <param name="imageBaseUrl">URL where saved images will be served from</param>
		public LocalFileImageUpload(string localImagePath, string imageBaseUrl)
		{
			_localImagePath = localImagePath;
			_imageBaseUrl = imageBaseUrl;
		}

		readonly string _localImagePath;
		readonly string _imageBaseUrl;

		/// <summary>
		/// Stores an image locally in the local image path.
		/// </summary>
		/// <param name="filename">filename to be used</param>
		/// <param name="imageStream">image data to be saved</param>
		/// <returns>a URL pointing to the saved image</returns>
		public async Task<string> StoreImage(string filename, Stream imageStream)
		{
			// Work out the full path including filename where the image will be saved to.
			var fullFileName = Path.Combine(_localImagePath, filename);

			// Read the content from the incoming image stream and write to the file system.
			// Deletes if the file already exists.
			using (var fileStream = new FileStream(fullFileName, FileMode.Create, FileAccess.Write))
			{
				await imageStream.CopyToAsync(fileStream);
			}

			// Return the url of the stored file.
			return _imageBaseUrl + filename;
		}
	}
}
