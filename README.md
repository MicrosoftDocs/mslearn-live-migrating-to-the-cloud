# Microsoft Learn Live

Welcome to Microsoft Learn Live! Microsoft Learn Live is a series of guided, live courses, presented on Twitch and designed to increase your existing knowledge of Azure technologies.

You can find all the details about Learn Live on our website at [docs.microsoft.com/learnlive](https://docs.microsoft.com/learnlive).

Learn Live is part of [Microsoft Learn](https://docs.microsoft.com/learn) where you find a thoroughly designed micro-learning experience, combined with a hands-on approach that helps you arrive at your goals faster, with more confidence and at your own pace. 

## Series overview

Our first series is titled "Migrate to the cloud". We have created a scenario where we assume that you are a .NET developer working on an in-house system, and now it is time to make a move into the cloud. You work for a fictitious company called VanArsdel Ltd. VanArsdel is in the real estate business, and as part of this, they run a beautiful website where they are selling real estate property.

There is a deployed version of the application available at [vanarsdel-realestate.azurewebsites.net](https://vanarsdel-realestate.azurewebsites.net).

To get the most out of this course, you…

- are familiar with Visual Studio, C#, and the basics of ASP.NET Core. We are not going to be going into any depth with ASP.NET Core, so it’s not crucial you are an expert with ASP.NET Core, but it helps you read through the code. 
- know the basics of SQL, potentially with an on-premises SQL Server installation
- are familiar with what Azure and “the cloud” is
- have navigated the Azure Portal 
- have created some Azure resources and possibly tried out some demos, or even better have gone through some Learn modules.

We are aiming this content at beginner to intermediate users of Azure. 

## Prepare for the sessions

To follow along with the exercises of the sessions, please **start by forking this repository into your own Github account**. You can do this by either clicking the "Fork" button top right or by using this link: [I prefer fork links over fork buttons.](https://github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/fork)

### Use the Microsoft Learn Live Sandbox to get free access to Azure resources

We use Azure throughout this series to create resources like Azure App Services, Azure SQL Database, and Azure Storage. Some of these resources are available for free while others are paid offers. To follow along with our series, you have two options.

- Option 1: Use your Azure subscription and clean up unused resources manually if you no longer need them, to avoid unintended costs. This gives you the benefit of having a persisted environment from the first all to the last session of our series. It also allows you to use all the features of Azure.
- Option 2: Use our Microsoft Learn Sandbox ([click here to activate](https://aka.ms/learnlivesandbox)). The sandbox provides you with a concierge subscription and a temporary resource group. The sandbox deletes itself after four hours. You do not have to pay anything for using the sandbox. It is entirely free. The sandbox offers most of the Azure features needed for this series. Some resources, however, are not available. If a feature is unavailable in the sandbox, we call it out explicitly during the delivery of the session. 

### Prepare for session 1: "Choose the best hosting option and deploy the app"

* Choose an appropriate hosting model
* Deploy the application to Azure

[Open instructions](./session1.md)

------

### Prepare for session 2: "Choose an appropriate database solution"

* Select the appropriate Azure database solution for VanArsdel
* Migrate on-premises data into Azure

[Open instructions](./session2.md)

------

### Prepare for session 3: "Choose an appropriate database solution"

* Identify the benefits of automated deployments vs manual deployment
* Automate your build and deployment using Azure App Service Deployment Center

[Open instructions](./session3.md)

------

### Prepare for session 4: "Identify the benefits of Azure Storage"

* Analyze existing storage implementation
* Explain the four Azure Storage services
* Select an appropriate storage approach

[Open instructions](./session4.md)

------

### Prepare for session 5: "Monitoring and scaling your applications in Azure"

* Monitor your application against metrics

* Configure Alerts when your application hits certain thresholds

* Setup scaling rules for your application

[Open instructions](./session5.md)

------

## Resources

* Azure Portal: [portal.azure.com](https://portal.azure.com)
* Code repository: [aka.ms/vanarsdelrepo](https://aka.ms/vanarsdelrepo)

# Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

# Legal Notices

Microsoft and any contributors grant you a license to the Microsoft documentation and other content in this repository under the [Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode), see the [LICENSE](LICENSE) file, and grant you a license to any code in the repository under the [MIT License](https://opensource.org/licenses/MIT), see the [LICENSE-CODE](LICENSE-CODE) file.

Microsoft, Windows, Microsoft Azure and/or other Microsoft products and services referenced in the documentation may be either trademarks or registered trademarks of Microsoft in the United States and/or other countries. The licenses for this project do not grant you rights to use any Microsoft names, logos, or trademarks. Microsoft's general trademark guidelines can be found at http://go.microsoft.com/fwlink/?LinkID=254653.

Privacy information can be found at https://privacy.microsoft.com/en-us/

Microsoft and any contributors reserve all other rights, whether under their respective copyrights, patents, or trademarks, whether by implication, estoppel or otherwise.