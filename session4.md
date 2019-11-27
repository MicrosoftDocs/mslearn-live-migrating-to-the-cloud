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

`wget -O script3.bash https://raw.githubusercontent.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/rr-azcli/scripts/02_deploy_app_service_and_database.bash && chmod +x ./script3.bash && ./script3.bash`

**Note:** The script will prompt you to enter the URL of your fork of the Github repo. 

When finished, the script will output the URL of the App Service and append the query parameter `?forceMigration=true` - please follow this link to ensure the database gets populated with data.

You are now ready to join session four! :-)