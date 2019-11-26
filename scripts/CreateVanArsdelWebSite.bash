#/bin/bash

# Setup the VanArsdel Repo in your system, either against the concierge or against an Azure Account

# It's the combination of information from the following templates

# Create a web app with appropriate SQL Database
# https://docs.microsoft.com/en-au/azure/app-service/scripts/cli-connect-to-sql?toc=%2fcli%2fazure%2ftoc.json

# Create a web app with Storage
# https://docs.microsoft.com/en-au/azure/app-service/scripts/cli-connect-to-storage?toc=%2fcli%2fazure%2ftoc.json

# Create a web app with Github
# https://docs.microsoft.com/en-au/azure/app-service/scripts/cli-deploy-local-git?toc=%2fcli%2fazure%2ftoc.json


# Set Application Properties
# https://docs.microsoft.com/en-us/cli/azure/webapp/config/appsettings?view=azure-cli-latest#az-webapp-config-appsettings-set

# Variables
suffix=$RANDOM
resourceGroup="VanArsdelLearnLive$suffix"
appName="VanArsdelAppAndSQL$suffix"
appPlanName="ap-$appName"
location="centralus"
serverName="vanardselappandsql$suffix"
databaseName="VanArsdelData"
sqlServerUsername="VanArsdelAdmin"
sqlServerPassword="MyVassword##"
storageName="vanarsdelstorage$suffix"
storageContainer="propertyimages"
gitdirectory="https://github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/"
# Set this to either "src/1 - Starter/RealEstate.csproj" or "src/2 - Completed/RealEstate.csproj"
kuduBuildProject="src/1 - Starter/RealEstate.csproj"

# ----------------------------------------------------------------------------------

# Login to sandbox directory - not required when using cloud shell
# az login --tenant learn.docs.microsoft.com

# Only when using sandbox: get sandbox' only resource group name
resourceGroup=$(az group list --query '[0].name' --output tsv)

# Create a resource group - only if not in sandbox. Cannot create new groups in sandbox.
az group create --name $resourceGroup --location $location

# Set defaults for all following commands
az configure --defaults group=$resourceGroup
az configure --defaults location=$location 

# Create an App Service plan
az appservice plan create --name $appPlanName --sku FREE

# Create a Web App in the App Service Plan
az webapp create --name $appName --plan $appPlanName

# Add a setting for Kudu so it knows which project to build.
az webapp config appsettings set --name $appName --settings PROJECT=$kuduBuildProject

# Create a SQL Database Server
az sql server create --name $serverName --admin-user $sqlServerUsername --admin-password $sqlServerPassword

# Allow Azure resources to access the server - strangely, this is done by setting a firewall rule from 0.0.0.0 to 0.0.0.0
az sql server firewall-rule create --server $serverName --name AllowAzureResources --start-ip-address "0.0.0.0" --end-ip-address "0.0.0.0"

# Create the database in the database server using a basic (DTU) tier.
az sql db create --server $serverName --name $databaseName --service-objective Basic

# Create a database connection string
connstring=$(az sql db show-connection-string --name $databaseName --server $serverName --client ado.net --output tsv)

# Add credentials to connection string
connstring=${connstring//<username>/$sqlServerUsername}
connstring=${connstring//<password>/$sqlServerPassword}

# Store the SQL Connection string to the database
az webapp config connection-string set -n $appName -t SQLAzure --settings DefaultConnection=$connstring

# Setup Github deployment against the site
az webapp deployment source config --branch master --name $appName --repo-url $gitdirectory

# Create Storage Account
az storage account create --name $storageName --sku Standard_LRS

storageconnstr=$(az storage account show-connection-string --name $storageName --query connectionString --output tsv)
storageaccountkey=${ConnStr#*AccountKey=}

az webapp config appsettings set --name $appName --settings "CloudStorageAccountName=$storageName"
az webapp config appsettings set --name $appName --settings "CloudStorageAccountKey=$storageaccountkey"
az webapp config appsettings set --name $appName --settings "CloudStorageBlobContainer=$storageContainer"
az webapp config appsettings set --name $appName --settings "CloudStorageBaseUrl=https://$storageName.blob.core.windows.net/"                
