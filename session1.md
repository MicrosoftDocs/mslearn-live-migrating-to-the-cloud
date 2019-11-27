# Session 1: "Choose the best hosting option and deploy the app"

In session one, we move the locally running ASP.NET Core MVC application into an Azure App Service. Before we get there, we want to make sure the app is running locally.

In this session, you will:

* Choose an appropriate hosting model
* Deploy the application to Azure

**Note for Mac users:** You cannot run the app locally. Although our application is based on .NET Core and can be deployed to Linux, it is using "Microsoft SQL Server Express Local DB" which is not available for macOS. In our second session, we migrate the database into the cloud. When this is done you will be able to follow along with Visual Studio Code or Visual Studio 2019 for macOS.

- Fork our repository if not already done ([fork now](https://github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/fork))
- Clone the repository to your PC
- Open the starter solution under "src/1 - Starter" (you can use Visual Studio 2019 or Visual Studio Code)
- Build and run the app
- It will open the browser and show an error about a missing database migration 
- Click the button shown to start the migration (alternatively, you can run `dotnet ef database` update on the command line)
- When the migration has completed, refresh the page
