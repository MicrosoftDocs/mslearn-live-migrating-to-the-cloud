using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;

namespace RealEstate.Services
{
	public class StorageUpload : IImageUpload
	{
		private readonly StorageUploadConfiguration config;

		public StorageUpload(StorageUploadConfiguration config)
		{
			this.config = config;
		}

		public async Task<string> StoreStream(string suggestedFilename, Stream stream)
		{
			// create connection to Azure Storage
			var storageAccount = new CloudStorageAccount(
				new StorageCredentials(config.AccountName, config.AccountKey),
				blobStorageUri: new StorageUri(new Uri(config.BlobStorageBaseUrl)),
				queueStorageUri: null,
				tableStorageUri: null,
				fileStorageUri: null);


			var blobClient = storageAccount.CreateCloudBlobClient();

			// get access to the container and blob
			var container = blobClient.GetContainerReference(config.ContainerName);
			await container.CreateIfNotExistsAsync();
			await container.SetPermissionsAsync(new BlobContainerPermissions() {
				PublicAccess = BlobContainerPublicAccessType.Blob
			});

			var fileName = System.IO.Path.GetFileName(suggestedFilename);
			var blob = container.GetBlockBlobReference(fileName);

			// delete the blob if it exists
			var fileExists = await blob.ExistsAsync();
			if (fileExists)
			{
				await blob.DeleteAsync();
			}

			await blob.UploadFromStreamAsync(stream);

			var fullImagePath = RealEstateHelpers.CombineUri(config.BlobStorageBaseUrl, config.ContainerName, fileName);
			return fullImagePath;
		}
	}
}
