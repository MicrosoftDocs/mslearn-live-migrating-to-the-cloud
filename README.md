# Microsoft Learn Live: Migrate to the cloud

Our sessions use the content of this repository to demonstrate the migration of an on-premises application into Azure. 

There is a deployed version of the appplication available at [vanarsdel-realestate.azurewebsites.net](https://vanarsdel-realestate.azurewebsites.net).

## Resources
We keep a list of all resources (links, apps) we use in the sessions in this [resources.md](resources.md) file.

## Prepare your Github repository
To follow along with the exercises of the sessions, please fork this repository into your own Github account. You can do this by either clicking the "Fork" button top right or by following this link:

[I prefer fork links over fork buttons.](https://github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/fork)

## Setup your Azure environment
If you are planning to follow all sessions from beginning to end and have your own Azure subscription there will be no need to use the following instructions. If, however, you quickly want to (re)create some resources or you work in a sandbox environment, the information below will come handy.

**Note:** When deploying the individual resources, make sure you pick the same subscription and resource group for all of them.

## Create the web application

We provide so called ARM (Azure Resource Manager) templates to help you automate the deployment of Azure resources like the web app. Whenever you deploy a resource there are some basic settings that must always be configured:

* **Subscription** - select the Azure subscription you would like to deploy the resource to. This can be your private subscription, a free trial or a sandbox subscription. If you deploy multiple resources make sure to always select the same subscription.
* **Resource group** - resource groups make it easier to manager multiple resources by bundling them together. When deploying your first resource you'd likely create a new resource group for all resources of this project. For subsequent deployments, select the same resource group.
* **Location** - defines to which data center your resources will be deployed to. If you select a resource group, this dropdown may be deactivated because the resource group already defines the location.

### Option 1: Create the web application without code
This will take you to the Azure Portal and ask for the credentials neccessary to create an App Service Plan and an empty App Service. You can then manually deploy the solution from Visual Studio or setup automatic deployment.

You will have to provide the following credentials:

* **App Service Name** - this will define the URL of your web application. Make sure to only use characters that are allowed in a URL. We recommend 'a' - 'z' and 0 - 9 and hyphens; no spaces. As this is going to be a URL it must be globally unique. We recommend to add your initials as a suffix and a random number. If the name is not unique, you will get an error during deployment.
* **Hosting Plan Name** - this is the name of the App Service Plan your web application (App Service) will be hosted under. This name must be unique within your subscription. You can keep the default, specify a different name or specify a name of a service plan that already exists (this would create the web app under the existing plan).
* **Sku Code** - Azure defines different price tiers "F1" is "free", "S1" is "standard" and costs money but has more options. We recommend to go with the free tier and change it later, if neccessary.

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fappservice_plan_and_appservice.json"><img src="armtemplates/deploybutton.png"></a>

### Option 2: Create the web application and reference code from Github
This template will create the same resources as option 1, but will allow to select a Github repo and a branch to build. The deployment will not be automatic/continous but instead you will be able to go to the web app's Deployment Center option and click the "Sync" button at the top to get the latest sources and have them built. For automatic deployments, see the instructions in this document.

You will have to provide the following credentials:

* **App Service Name**, **Hosting Plan Name** and **Sku Code** - please see comments of option 1.
* **Repo URL** - this is the URL of the forked repository
* **Branch** - the branch you want to deploy to the web application on Azure. Select between "starter" to get the original solution or "blobstorage" to get the version that is using Azure blob storage to store assets.

**Note:** after deployment the web app will not work. Further changes must be made. You will need a SQL database instance and configure the connection string (see instructions below). You will also need a storage account if you select the branch "blobstorage" and configire its connection string (see instructions below).

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fappservice_plan_and_appservice_with_code.json"><img src="armtemplates/deploybutton.png"></a>


# Create the database server instance and the database
The following template helps you create a database server and a SQL database instance. 

You will have to provide the following credentials:

* **Database Server Name** - this will define the URL of your database server. Make sure to only use characters that are allowed in a URL. We recommend 'a' - 'z' and 0 - 9 and hyphens; no spaces. As this is going to be a URL, it must be globally unique. We recommend to add your initials as a suffix and a random number. If the name is not unique, you will get an error during deployment.
* **Database Name** - the name of the database within your database server. It must be unique within the database server.
* **Sql Administrator Login** - the login name of the administrator of the database. It will be part of the database's connection string. It's a SQL Identifier, and not a typical system name (like admin, administrator, sa, root, dbmanager, loginmanager, etc.), or a built-in database user or role (like dbo, guest, public, etc.). Make sure your name doesn't contain whitespaces, unicode characters, or nonalphabetic characters, and that it doesn't begin with numbers or symbols.
* **Sql Administrator Password** - the login password. Your password must be at least 8 characters in length. Your password must contain characters from three of the following categories – English uppercase letters, English lowercase letters, numbers (0-9), and non-alphanumeric characters (!, $, #, %, etc.). The password may not contain parts of the administrator login name.

**Note:** the database will not be configured in the app service. To do this, wait for the deployment to complete, get the database's connection string and insert it in the app service's configuration section where you will find a connection string setting called "DefaultConnection". Also, you will want to update the database's firewall settings to allow your development machine to connect to the database.

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fdatabase.json"><img src="armtemplates/deploybutton.png"></a>

# Configure automatic deployment of the app service
If you want the web application to be deployed automatically if a change in your repository has been madem you can do this manually by opening the app in Azure Portal and select "Deployment Center". There, you can setup a "App Service Build Service" (Kudu) based build pipeline using Github as the source code provider.

**Why no script?** Configuring automatic continous deployment will require you to authorize Azure to acccess your Github account and a callback (webhook) must be created within the repository. It is faster to go through the portal which provides an easy to understand UI.

# Add a blob storage to your Azure subscription
As part of the refactoring process of the web application we integrate blob storage.

To help you create the required storage account, use the template below. The resulting storage account will have a blob storage with a precreated container names "propertyimages" which is used by the web appllication.

You will have to provide the following credentials:

* **Storage Account Name** - Specifies the name of the Azure Storage account. This must be globally unique and 3 to 24 characters long, all lowercase, no hyphens.

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fstorageaccount.json"><img src="armtemplates/deploybutton.png"></a>


# Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

# Legal Notices

Microsoft and any contributors grant you a license to the Microsoft documentation and other content
in this repository under the [Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode),
see the [LICENSE](LICENSE) file, and grant you a license to any code in the repository under the [MIT License](https://opensource.org/licenses/MIT), see the
[LICENSE-CODE](LICENSE-CODE) file.

Microsoft, Windows, Microsoft Azure and/or other Microsoft products and services referenced in the documentation
may be either trademarks or registered trademarks of Microsoft in the United States and/or other countries.
The licenses for this project do not grant you rights to use any Microsoft names, logos, or trademarks.
Microsoft's general trademark guidelines can be found at http://go.microsoft.com/fwlink/?LinkID=254653.

Privacy information can be found at https://privacy.microsoft.com/en-us/

Microsoft and any contributors reserve all other rights, whether under their respective copyrights, patents,
or trademarks, whether by implication, estoppel or otherwise.
