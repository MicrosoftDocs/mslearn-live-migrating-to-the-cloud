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

# Login to sandbox directory - not required when using cloud shell
# az login --tenant learn.docs.microsoft.com

# Only when using sandbox: get sandbox' only resource group name
$resourceGroup=$(az group list --query '[0].name' --output tsv)

# Create a resource group - only if not in sandbox. Cannot create new groups in sandbox.
az group create --name $resourceGroup --location $location

# Set defaults for all following commands
az configure --defaults group=$resourceGroup
az configure --defaults location=$location 

# Create an App Service plan
az appservice plan create --name $appPlanName --sku FREE

# Create a Web App in the App Service Plan
az webapp create --name $appName --plan $appPlanName

# Create a SQL Database Server
az sql server create --name $serverName --admin-user $sqlServerUsername --admin-password $sqlServerPassword

# Allow Azure resources to access the server - strangely, this is done by setting a firewall rule from 0.0.0.0 to 0.0.0.0
az sql server firewall-rule create --server $serverName --name AllowAzureResources --start-ip-address "0.0.0.0" --end-ip-address "0.0.0.0"

# Create the database in the database server using a basic (DTU) tier.
az sql db create --server $serverName --name $databaseName --service-objective Basic

# TODO: Set config param to deploy starter or completed ("name": "PROJECT", "value": "src/1 - Starter/RealEstate.csproj")
# TODO: Make deployment automatic
# Setup Github deployment against the site
az webapp deployment source config --branch master --manual-integration --name $appName --repo-url $gitdirectory

# Create a database connection string
connstring=$(az sql db show-connection-string --name $databaseName --server $serverName --client ado.net --output tsv)

# Add credentials to connection string
connstring=${connstring//<username>/$sqlServerUsername}
connstring=${connstring//<password>/$sqlServerPassword}

# Store the SQL Connection string to the database
az webapp config connection-string set -n $appName -t SQLAzure --settings DefaultConnection=$connstring

# Create Storage Account
az storage account create --name $storageName --sku Standard_LRS

storageconnstr=$(az storage account show-connection-string --name $storageName --resource-group $resourceGroup \
    --query connectionString --output tsv)
position=echo $storageconnstr | grep -b -o AccountKey

az webapp config appsettings set --name $appName --resource-group $resourceGroup \
    --settings "CloudStorageAccountName=$storageName"
az webapp config appsettings set --name $appName --resource-group $resourceGroup \
    --settings "CloudStorageAccountKey=$storageconnstr"
az webapp config appsettings set --name $appName --resource-group $resourceGroup \
    --settings "CloudStorageBlobContainer=$storageContainer"
az webapp config appsettings set --name $appName --resource-group $resourceGroup \
    --settings "CloudStorageBaseUrl=https://$storageName.blob.core.windows.net/"                