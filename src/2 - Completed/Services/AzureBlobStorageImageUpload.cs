using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;

namespace RealEstate.Services
{
	public class AzureBlobStorageImageUpload : IImageUpload
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="accountName">Name of storage account. Can be found in storage account's settings -> access keys.</param>
		/// <param name="accountKey">Access key of storage account. Can be found in storage account's settings -> access keys.</param>
		/// <param name="containerName">Name of the container we want to upload into.</param>
		/// <param name="baseUrl">URL of the storage account. This is https://STORAGE_ACCOUNT_NAME.blob.core.windows.net</param>
		public AzureBlobStorageImageUpload(string accountName, string accountKey, string containerName, string baseUrl)
		{
			_accountName = accountName;
			_accountKey = accountKey;
			_containerName = containerName;
			_baseUrl = baseUrl;
		}

		readonly string _accountName;
		readonly string _accountKey;
		readonly string _containerName;
		readonly string _baseUrl;

		/// <summary>
		/// Stores an image in the configured Azure blob storage account.
		/// </summary>
		/// <param name="filename">name of the blob</param>
		/// <param name="imageStream">image data to be saved</param>
		/// <returns></returns>
		public async Task<string> StoreImage(string filename, Stream imageStream)
		{
			// create connection to Azure Storage
			var storageAccount = new CloudStorageAccount(
				// Credentials.
				new StorageCredentials(_accountName, _accountKey),
				// Base URI of the blob storage.
				new StorageUri(new Uri(_baseUrl)),
				// URIs of other storage options we are not using (eg Queue).
				null, null, null);

			var blobClient = storageAccount.CreateCloudBlobClient();

			// Get access to the container and blob.
			var container = blobClient.GetContainerReference(_containerName);

			await container.CreateIfNotExistsAsync();
			await container.SetPermissionsAsync(new BlobContainerPermissions() {
				PublicAccess = BlobContainerPublicAccessType.Blob
			});

			var blob = container.GetBlockBlobReference(filename);

			// Delete the blob if it exists
			var blobExists = await blob.ExistsAsync();
			if (blobExists)
			{
				await blob.DeleteAsync();
			}

			await blob.UploadFromStreamAsync(imageStream);

			// The image's URL is in the format "BASE_URL/CONTAINER_NAME/FILENAME".
			var fullImagePath = RealEstateHelpers.CombineUri(_baseUrl, _containerName, filename);
			return fullImagePath;
		}
	}
}
