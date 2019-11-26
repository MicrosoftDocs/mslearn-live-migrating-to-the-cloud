# Variables
suffix=$RANDOM
resourceGroup="VanArsdelLearnLive$suffix"
appName="VanArsdelAppAndSQL$suffix"
appPlanName="ap-$appName"
location="centralus"
serverName="vanardselappandsql$suffix"
# Get Github repo from script parameters
gitDirectory=$1
kuduBuildProject="src/1 - Starter/RealEstate.csproj"

echo Microsoft Learn Live Deployment script
echo .

# If no URL is provided as a parameter, ask user to enter now.
while [ -z $gitDirectory ]
do
echo Please enter the URL of the Github repo (e.g., https: \/\/github.com\/MicrosoftDocs\/mslearn-live-migrating-to-the-cloud\/)
read gitDirectory
done

echo This is what we will use to deploy the app:
echo ...Github repository: $gitDirectory
echo ...Project being built: $kuduBuildProject
echo ...Location use: $location
echo ...App Service name: $appName
echo .

echo Logging in to Learn Live Sandbox - make sure you have activated one at aka.ms/learnlivesandbox...
az login --tenant learn.docs.microsoft.com
echo .

echo Getting resource group name from sandbox...
resourceGroup=$(az group list --query '[0].name' --output tsv)
echo Resource group: $resourceGroup
echo .

# Set defaults for all following commands
az configure --defaults group=$resourceGroup
az configure --defaults location=$location 

echo Creating App Service Plan using a FREE tier...
az appservice plan create --name $appPlanName --sku FREE
echo .

echo Creating App Service...
az webapp create --name $appName --plan $appPlanName
echo .

echo Configuring deployment...
az webapp config appsettings set --name $appName --settings PROJECT=$kuduBuildProject
az webapp deployment source config --branch master --name $appName --repo-url $gitdirectory

echo .
echo Done. :-)