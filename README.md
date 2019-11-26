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

## Set up your  environment

The following paragraphs provide information how to prepare your (development) environment to be able to follow along the live sessions.

To follow along with the exercises of the sessions, please fork this repository into your own Github account. You can do this by either clicking the "Fork" button top right or by using this link: [I prefer fork links over fork buttons.](https://github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/fork)

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

#### If you are using your own Azure subscription

* Open [Azure Portal](https://portal.azure.com) in your browser and select your subscription
* Open the Cloud Shell (the button is located at the very top, next to the notifications bell and looks like this: `>_`) and select to use a "Bash" shell.

#### If you are using the Learn Live Sandbox

* Go to your [Learn Live Sandbox activation page](https://aka.ms/learnlivesandbox)
* Locate Azure Cloud Shell on the right hand side

In Cloud Shell, execute the following command which will execute a script to create an App Service and deploy the app directly from Github:

`wget -O - https://raw.githubusercontent.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/rr-azcli/scripts/sandbox/01_sandbox_deploy_app_service.bash | bash`

When finished, open [Azure Portal](https://portal.azure.com) in your browser and select your subscription ([click here to directly open the Learn Live Sandbox subscription](https://portal.azure.com/learn.docs.microsoft.com?azure-portal=true)) to see the created resources.Contributing

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
