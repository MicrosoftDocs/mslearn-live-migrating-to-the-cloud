namespace RealEstate.Services
{
	public class StorageUploadConfiguration
	{
		/// <summary>
		/// Name of storage account. Can be found in storage account's settings -> access keys.
		/// </summary>
		public string AccountName { get; set; }

		/// <summary>
		/// Access key of storage account. Can be found in storage account's settings -> access keys.
		/// </summary>
		public string AccountKey { get; set; }

		/// <summary>
		/// Name of the container we want to upload into.
		/// </summary>
		public string ContainerName { get; set; }

		/// <summary>
		/// URL of the storage account. This is https://STORAGE_ACCOUNT_NAME.blob.core.windows.net
		/// </summary>
		public string BlobStorageBaseUrl { get; set; }
	}
}
