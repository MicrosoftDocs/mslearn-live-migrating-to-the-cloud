# Prepare for session 2: "Choose an appropriate database solution"

Session one ended with the web application being migrated into an Azure App Service. In session two, we migrate the local database and its data into the cloud.

In this session, you will:

* Select the appropriate Azure database solution for VanArsdel
* Migrate on-premises data into Azure

If you do not have access to the deployed solution (maybe you deleted it to save money or used the Learn Live Sandbox), please follow these instructions.

We have prepared a script that:

1. Creates an App Service Plan
2. Creates an App Service
3. Deploys the app directly from Github into the App Service

#### If you are using your Azure subscription

- Open [Azure Portal](https://portal.azure.com) in your browser and select your subscription
- Open the Cloud Shell (the button is located at the very top, next to the notifications bell and looks like this: >_) and select to use a "Bash" shell.

#### If you are using the Learn Live Sandbox

- Go to your [Learn Live Sandbox activation page](https://aka.ms/learnlivesandbox)
- Locate Azure Cloud Shell on the right-hand side

Copy the following command and paste it into Cloud Shell: 

`wget -O script1.bash https://raw.githubusercontent.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/rr-azcli/scripts/01_deploy_app_service.bash && chmod +x ./script1.bash && ./script1.bash`

**Note:** The script will prompt you to enter the URL of your fork of the Github repo. 

When finished, the script will output the URL of the App Service and append the query parameter `?forceMigration=true` - please follow this link to ensure the database gets populated with data.

You are now ready to join session two! :-)