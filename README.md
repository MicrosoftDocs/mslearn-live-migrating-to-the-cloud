# Microsoft Learn Live

Welcome to Microsoft Learn Live! Microsoft Learn Live is a series of guided, live courses, presented on Twitch and designed to increase your existing knowledge of Azure technologies.

You can find all the details about Learn Live on our website at [docs.microsoft.com/learnlive](https://docs.microsoft.com/learnlive).

Learn Live joins the dots together for learning Azure by focusing on solutions and not just the individual parts of Azure.

Learn Live is part of [Microsoft Learn](https://docs.microsoft.com/learn) where you find a thoroughly designed micro-learning experience, combined with a hands-on approach that helps you arrive at your goals faster, with more confidence and at your own pace. 

## Series overview

Our first series is titled "Migrate to the cloud". We have created a scenario where  we assume that you are a .NET developer working on an inhouse system and now  it is time to make the move into the cloud. You work for a fictitious company called VanArsdel Ltd. VanArsdel is in the real estate business and as part of this they run a beautiful website where they are selling real estate property.

There is a deployed version of the application available at [vanarsdel-realestate.azurewebsites.net](https://vanarsdel-realestate.azurewebsites.net).

To get  the most out of this course, you… 

* are familiar with Visual Studio, C# and the basics of ASP.NET Core. We are not going to be going  into any depth with ASP.NET Core, so it’s not crucial you are an expert with  ASP.NET Core, but an understanding will help you be able to read through the  code. 
* know the basics of SQL, potentially with an on-premises SQL Server  installation
* are familiar with what Azure and “the cloud” is
* have navigated the Azure Portal 
* have created some Azure resources and possibly tried out some demos, or even better have gone through some Learn modules.

We are aiming this content at beginner to intermediate users of Azure. 

## About this repository

This repository accompanies our first series of sessions. It contains all our code samples and projects but also details the steps necessary to prepare your environment for each of the sessions. Resources

We keep a list of all resources (links, apps) we use in the sessions in this [resources.md](resources.md) file.

To follow along with the exercises of the sessions, please fork this repository into your own Github account. You can do this by either clicking the "Fork" button top right or by using this link: [I prefer fork links over fork buttons.](https://github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/fork)

## Set up your  environment

The following paragraphs provide information how to prepare your (development) environment to be able to follow along the live sessions.

### Microsoft Learn Live Sandbox

We use Azure throughout this series to create resources like Azure App Services, Azure SQL Database, and Azure Storage. Some of these resources are available for free, others are paid offers. To follow along with our series, you have two options.

* Option 1: Use your own Azure subscription and clean up unused resources manually if you no longer need them, to avoid unintended cost. This will give you the benefit of having a persisted environment from the first all to the last session of our series. It also allows you to use all features of Azure.
* Option 2: Use our Microsoft Learn Sandbox ([click here to activate](https://aka.ms/learnlivesandbox)). The sandbox provides you with a concierge subscription and a temporary resource group that will automatically be deleted after four hours. You do not have to pay anything for using the sandbox, it is completely free. The sandbox offers most of the Azure features needed for this series. Some resources however, are not available. If a feature is unavailable in the sandbox, we call it out explicitly during the delivery of the session. 

### Prepare for "Session 1: Deploy the web application"

In session one we move the locally running ASP.NET Core MVC application into an Azure App Service. Before we get there, we want to make sure the app is running locally.

**Note for Mac users:** You will not be able to run the app locally. Although our application is based on .NET Core and can be deployed to Linux, it is using "Microsoft SQL Server Express Local DB" which is not available for macOS. In our second session we migrate the database into the cloud. When this is done you will be able to follow along with Visual Studio Code or Visual Studio 2019 for macOS.

* Fork our repository if not already done ([fork now](https://github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/fork))
* Clone the repository to your PC
* Open the starter solution under "src/1 - Starter" (you can use Visual Studio 2019 or Visual Studio Code)
* Build and run the app
* It will open the browser and show an error about a missing database migration 
* Click the button shown to start the migration (alternatively, you can run `dotnet ef databse update` on the command line)
* When the migration has completed, refresh the page

### Prepare for "Session 2: Migrate the database into the cloud"

Session one ended with the web application being migrated into an Azure App Service. In session two we migrate the local database and its data into the cloud.

If you do not have access to the deployed solution (maybe you deleted it to save money or used the Learn Live Sandbox), please follow these instructions.

* Fork our repository if not already done ([fork now](https://github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/fork))
* Use the Learn Live Sandbox if desired ([click here to activate](https://aka.ms/learnlivesandbox)

#### If you are using your own Azure subscription

* Open [Azure Portal](https://portal.azure.com) in your browser and select your subscription
* Open the Cloud Shell 

#### If you are using the Learn Live Sandbox

* Open [Azure Portal](https://portal.azure.com) in your browser and select your subscription ([click here to directly open the Learn Live Sandbox subscription](https://portal.azure.com/learn.docs.microsoft.com?azure-portal=true))
* 

We provide so called ARM (Azure Resource Manager) templates to help you automate the deployment of Azure resources like the web app. Whenever you deploy a resource there are some basic settings that must always be configured:

* **Subscription** - select the Azure subscription you would like to deploy the resource to. This can be your private subscription, a free trial or a sandbox subscription. If you deploy multiple resources make sure to always select the same subscription.
* **Resource group** - resource groups make it easier to manager multiple resources by bundling them together. When deploying your first resource you'd likely create a new resource group for all resources of this project. For subsequent deployments, select the same resource group.
* **Location** - defines to which data center your resources will be deployed to. If you select a resource group, this dropdown may be deactivated because the resource group already defines the location.

### Option 1: Create the web application without code
This will take you to the Azure Portal and ask for the credentials neccessary to create a free App Service Plan and an empty App Service. You can then manually deploy the solution from Visual Studio or setup automatic deployment.

You will have to provide the following credentials:

* **App Service Name** - this will define the URL of your web application. Make sure to only use characters that are allowed in a URL. We recommend 'a' - 'z' and 0 - 9 and hyphens; no spaces. As this is going to be a URL it must be globally unique. We recommend to add your initials as a suffix and a random number. If the name is not unique, you will get an error during deployment.
* **Hosting Plan Name** - this is the name of the App Service Plan your web application (App Service) will be hosted under. This name must be unique within your subscription. You can keep the default, specify a different name or specify a name of a service plan that already exists (this would create the web app under the existing plan).

**Note:** free app service plans (F1) are not available in all locations. To avoid errors while keeping the setup as simple as possible, _the ARM templates always use "Central US" for the location_, regardless of the selection in the location dropfown.

| Deployment options                                           |                                                              |
| :----------------------------------------------------------- | :----------------------------------------------------------: |
| Deploy to the currently selected Azure subscription          | <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fappservice_plan_and_appservice.json"><img src="armtemplates/deploybutton.png"></a> |
| Deploy using Microsoft Learn Sandbox (must be activated - [click here to activate](https://aka.ms/learnlivesandbox)) | <a href="https://portal.azure.com/learn.docs.microsoft.com?azure-portal=true#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fappservice_plan_and_appservice.json"><img src="armtemplates/deploybutton.png"></a> |

### Option 2: Create the web application and reference the starter solution from Github

This template will create the same resources as option one but will in addition allow you to select a Github repo containing the VanArsdel Ltd. real estate project to build and deploy to Azure.

From the selected repository the template will deploy the _starter_ solution which does not use an Azure Storage Account to persist images. Instead, images will be stored locally to the web project.

The deployment will not be automatic/continous. You will be able to go to the web app's Deployment Center option and click the "Sync" button at the top to get the latest sources and have them built. For automatic deployments, see the instructions further down in this document.

You will have to provide the following credentials:

* **App Service Name** and **Hosting Plan Name** - please see comments of option one for details.
* **Repo URL** - this is the URL of the forked repository 

After deployment, the web app will show you a warning message about setting a database connection string. You need a SQL database instance and configure the connection string (see instructions below).

**Note:** free app service plans (F1) are not available in all locations. To avoid errors while keeping the setup as simple as possible, _the ARM templates always use "Central US" for the location_, regardless of the selection in the location dropfown.

| Deployment options                                           |                                                              |
| :----------------------------------------------------------- | :----------------------------------------------------------: |
| Deploy to the currently selected Azure subscription          | <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fappservice_plan_and_appservice_with_code_starter.json"><img src="armtemplates/deploybutton.png"></a> |
| Deploy using Microsoft Learn Sandbox (must be activated - [click here to activate](https://aka.ms/learnlivesandbox)) | <a href="https://portal.azure.com/learn.docs.microsoft.com?azure-portal=true#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fappservice_plan_and_appservice_with_code_starter.json"><img src="armtemplates/deploybutton.png"></a> |

### Option 3: Create the web application and reference the completed solution from Github

This template will create the same resources as option two but deploy the _completed_ solution of the project which uses an Azure Storage Account instead of saving image files locally to the web project.

After deployment, the web app will show you a warning message about setting a database connection string. You need a SQL database instance and configure the connection string (see instructions below).

Also, you will have to create a Storage Account and configure the deployed web app to connect to it. For details see below.

**Note:** free app service plans (F1) are not available in all locations. To avoid errors while keeping the setup as simple as possible, _the ARM templates always use "Central US" for the location_, regardless of the selection in the location dropfown.

| Deployment options                                           |                                                              |
| :----------------------------------------------------------- | :----------------------------------------------------------: |
| Deploy to the currently selected Azure subscription          | <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fappservice_plan_and_appservice_with_code.json"><img src="armtemplates/deploybutton.png"></a> |
| Deploy using Microsoft Learn Sandbox (must be activated - [click here to activate](https://aka.ms/learnlivesandbox)) | <a href="https://portal.azure.com/learn.docs.microsoft.com?azure-portal=true#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fappservice_plan_and_appservice_with_code_completed.json"><img src="armtemplates/deploybutton.png"></a> |



# Create the database server instance and the database

The following template helps you create a database server and a SQL database instance. 

You will have to provide the following credentials:

* **Database Server Name** - this will define the URL of your database server. Make sure to only use characters that are allowed in a URL. We recommend 'a' - 'z' and 0 - 9 and hyphens; no spaces. As this is going to be a URL, it must be globally unique. We recommend to add your initials as a suffix and a random number. If the name is not unique, you will get an error during deployment.
* **Database Name** - the name of the database within your database server. It must be unique within the database server.
* **Sql Administrator Login** - the login name of the administrator of the database. It will be part of the database's connection string. It's a SQL Identifier, and not a typical system name (like admin, administrator, sa, root, dbmanager, loginmanager, etc.), or a built-in database user or role (like dbo, guest, public, etc.). Make sure your name doesn't contain whitespaces, unicode characters, or nonalphabetic characters, and that it doesn't begin with numbers or symbols.
* **Sql Administrator Password** - the login password. Your password must be at least 8 characters in length. Your password must contain characters from three of the following categories – English uppercase letters, English lowercase letters, numbers (0-9), and non-alphanumeric characters (!, $, #, %, etc.). The password may not contain parts of the administrator login name.

**Note:** the database will not be configured in the app service. To do this, wait for the deployment to complete, get the database's connection string and insert it in the app service's configuration section where you will find a connection string setting called "DefaultConnection". Also, you will want to update the database's firewall settings to allow your development machine to connect to the database.

| Deployment options                                           |                                                              |
| :----------------------------------------------------------- | :----------------------------------------------------------: |
| Deploy to the currently selected Azure subscription          | <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fdatabase.json"><img src="armtemplates/deploybutton.png"></a> |
| Deploy using Microsoft Learn Sandbox (must be activated - [click here to activate](https://aka.ms/learnlivesandbox)) | <a href="https://portal.azure.com/learn.docs.microsoft.com?azure-portal=true#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fdatabase.json"><img src="armtemplates/deploybutton.png"></a> |



# Configure automatic deployment of the app service
If you want the web application to be deployed automatically if a change in your repository has been madem you can do this manually by opening the app in Azure Portal and select "Deployment Center". There, you can setup a "App Service Build Service" (Kudu) based build pipeline using Github as the source code provider.

**Why no script?** Configuring automatic continous deployment will require you to authorize Azure to acccess your Github account and a callback (webhook) must be created within the repository. It is faster to go through the portal which provides an easy to understand UI.

# Add a blob storage to your Azure subscription
As part of the refactoring process of the web application we integrate blob storage.

To help you create the required storage account, use the template below. The resulting storage account will have a blob storage with a precreated container names "propertyimages" which is used by the web appllication.

You will have to provide the following credentials:

* **Storage Account Name** - Specifies the name of the Azure Storage account. This must be globally unique and 3 to 24 characters long, all lowercase, no hyphens.

| Deployment options                                           |                                                              |
| :----------------------------------------------------------- | :----------------------------------------------------------: |
| Deploy to the currently selected Azure subscription          | <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fstorageaccount.json"><img src="armtemplates/deploybutton.png"></a> |
| Deploy using Microsoft Learn Sandbox (must be activated - [click here to activate](https://aka.ms/learnlivesandbox)) | <a href="https://portal.azure.com/learn.docs.microsoft.com?azure-portal=true#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoftDocs%2Fmslearn-live-migrating-to-the-cloud%2Fmaster%2Farmtemplates%2Fstorageaccount.json"><img src="armtemplates/deploybutton.png"></a> |




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
