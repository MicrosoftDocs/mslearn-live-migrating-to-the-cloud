# Prepare for session 4: "Identify the benefits of Azure Storage"

Session three introduced automated builds and deployments to VanArsdel's project. This is handy, because in this session we are going to move away from our filesystem-based image storage to a cloud based solution. To get there, we are going to write some code and with automated builds in place, our deployed solution will automatically be updated on Azure.

In this session, you will:

* Analyze the existing storage implementation
* Explain the four Azure Storage services
* Select an appropriate storage approach

To follow along with the session, we recommend to get the project into the state we had at the end of session three. For your convenience, we provide a script for you that will perform the following steps:

1. Create an App Service Plan
2. Create an App Service
3. Deploy the app directly from Github into the App Service
4. Create a logical database server
5. Create an Azure SQL Database
6. Configure the App Service to connect to the database

#### If you are using your Azure subscription

- Open [Azure Portal](https://portal.azure.com) in your browser and select your subscription
- Open the Cloud Shell (the button is located at the very top, next to the notifications bell and looks like this: >_) and select to use a "Bash" shell.

#### If you are using the Learn Live Sandbox

- Go to your [Learn Live Sandbox activation page](https://aka.ms/learnlivesandbox)
- Locate Azure Cloud Shell on the right-hand side

Copy the following command and paste it into Cloud Shell:

`wget -O prepsession4.bash https://raw.githubusercontent.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/master/scripts/02_deploy_app_service_and_database.bash && chmod +x ./prepsession4.bash && ./prepsession4.bash`

**Note:** The script will prompt you to enter the URL of your fork of the Github repo. 

When finished, the script will output the URL of the App Service and append the query parameter `?forceMigration=true` - please follow this link to ensure the database gets populated with data.

You are now ready to join session four! :-)

## Resources

* Overiew of features of Azure Storage Account settings: [docs.microsoft.com/de-de/azure/storage/common/storage-introduction#types-of-storage-accounts](https://docs.microsoft.com/de-de/azure/storage/common/storage-introduction#types-of-storage-accounts)
* Storage Redundancy reference: [docs.microsoft.com/de-de/azure/storage/common/storage-redundancy](https://docs.microsoft.com/de-de/azure/storage/common/storage-redundancy)
* Azure Storage Explorer: [azure.microsoft.com/en-us/features/storage-explorer/](https://azure.microsoft.com/en-us/features/storage-explorer/)
* Windows.Azure.Storage.Blob Nuget: [www.nuget.org/packages/Microsoft.Azure.Storage.Blob/](https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob/)
* Microsoft Learn Module: [Store Application Data with Azure Blob storage](https://docs.microsoft.com/en-us/learn/modules/store-app-data-with-azure-blob-storage/)
* Microsoft Learn Module: [Organize Azure storage blobs with properties and metadata](https://docs.microsoft.com/en-us/learn/modules/organize-blobs-properties-metadata/6-add-blob-metadata-using-application-code)
* Microsoft Learn Module: [Optimize storage performance and costs using Blob storage tiers](https://docs.microsoft.com/en-us/learn/modules/optimize-archive-costs-blob-storage/)
* Microsoft Learn Module: [Secure your Azure Storage Account](https://docs.microsoft.com/en-us/learn/modules/secure-azure-storage-account/)
* Microsoft Learn Module: [https://docs.microsoft.com/en-us/learn/modules/connect-an-app-to-azure-storage/](Connect an app to Azure Storage)