using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	public class LocalFileImageUpload : IImageUpload
	{
		private readonly string baseImageFolder;
		private readonly string prefixUrl;

		public LocalFileImageUpload(string baseImageFolder, string prefixUrl)
		{
			this.baseImageFolder = baseImageFolder;
			this.prefixUrl = prefixUrl;
		}

		public async Task<string> StoreStream(string suggestedFilename, Stream stream)
		{
			// work out the full file name
			var fullFileName = Path.Combine(baseImageFolder, suggestedFilename);

			// delete the file if it exists
			if (File.Exists(fullFileName))
			{
				File.Delete(fullFileName);
			}

			// write the content from the incoming stream and write to the file stream
			using (var fs = new FileStream(fullFileName, FileMode.CreateNew))
			{
				await stream.CopyToAsync(fs);
			}

			// return the url of the stored file
			return prefixUrl + suggestedFilename;
		}
	}
}
