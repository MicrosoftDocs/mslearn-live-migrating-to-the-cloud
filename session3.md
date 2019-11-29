# Prepare for session 3: "Automate your build and deployment process"

At the end of the second session we had the VanArsdel solution running up on Azure as an App Service and made it connect to an Azure SQL database. The Azure Data Migration Assistant helped us move our data from the local database instance into the cloud.

In this session, you will:

* Identify the benefits of automated deployments vs manual deployment
* Automate your build and deployment using Azure App Service Deployment Center

To follow along with the session, we recommend to get the project into the state we had at the end of session two. For your convenience, we provide a script for you that will perform the following things:

1. Creates an App Service Plan
2. Creates an App Service
3. Deploys the app directly from Github into the App Service
4. Creates a logical database server
5. Creates an Azure SQL Database
6. Configures the App Service to connect to the database

#### If you are using your Azure subscription

- Open [Azure Portal](https://portal.azure.com) in your browser and select your subscription
- Open the Cloud Shell (the button is located at the very top, next to the notifications bell and looks like this: >_) and select to use a "Bash" shell.

#### If you are using the Learn Live Sandbox

- Go to your [Learn Live Sandbox activation page](https://aka.ms/learnlivesandbox)
- Locate Azure Cloud Shell on the right-hand side

Copy the following command and paste it into Cloud Shell:

`wget -O prepsession3.bash https://raw.githubusercontent.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/master/scripts/03_deploy_app_service_and_database.bash && chmod +x ./prepsession3.bash && ./prepsession3.bash`

**Note:** The script will prompt you to enter the URL of your fork of the Github repo. 

When finished, the script will output the URL of the App Service and append the query parameter `?forceMigration=true` - please follow this link to ensure the database gets populated with data.

You are now ready to join session three! :-)

## Resources

* Documentation: [Continuous deployment to Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/deploy-continuous-deployment)