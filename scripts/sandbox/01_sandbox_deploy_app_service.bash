#!/bin/bash

# This script is meant to be executed in the Learn Live Sandbox Cloud Shell.

# Variables
suffix=$RANDOM
resourceGroup="VanArsdelLearnLive$suffix"
appName="AppService-VanArsdel$suffix"
appPlanName="AppPlan-$appName"
location="centralus"
# Get Github repo from script parameters
gitDirectory=$1
kuduBuildProject="src/1 - Starter/RealEstate.csproj"

clear
printf "Microsoft Learn Live Deployment script\n"
printf "======================================\n"
printf "\n"

# If no URL is provided as a parameter, ask user to enter now.
while [ -z $gitDirectory ]
do
printf "No Github repo provided as a parameter.\n"
printf "Please enter the URL of the Github repo (e.g., https://www.github.com/MicrosoftDocs/mslearn-live-migrating-to-the-cloud/).\n"
printf "Github repo URL: "
read -p gitDirectory
done

printf
printf "This is what we will use to deploy the app:\n"
printf "...Github repository: %s\n" $gitDirectory
printf "...Project being built: %s\n" "$kuduBuildProject"
printf "...Location use: %s\n" $location
printf "...App Service name: %s\n" $appName
printf "\n"

# Only needed when executing locally and not in Cloud Shell
# echo "Logging in to Learn Live Sandbox - make sure you have activated one at aka.ms/learnlivesandbox. If you haven't, please cancel this script using CTRL+C."
# az login --tenant learn.docs.microsoft.com
# printf "\n"

printf "Getting resource group name from sandbox..."
resourceGroup=$(az group list --query '[0].name' --output tsv)
printf "Resource group: %s\n" $resourceGroup
printf "\n"

# Set defaults for all following commands
az configure --defaults group=$resourceGroup
az configure --defaults location=$location 

printf "Creating App Service Plan using a FREE tier...\n"
az appservice plan create --name $appPlanName --sku FREE
printf "\n"

printf "Creating App Service (this can take a while)...\n"
az webapp create --name $appName --plan $appPlanName
printf "\n"

printf "Configuring app settings:\n"
printf "...App name: %s\n" $appName
printf "...Project to build: %s\n" $kuduBuildProject
printf "...Repo: %s\n" $gitDirectory
az webapp config appsettings set --name "$appName" --settings PROJECT="$kuduBuildProject"

printf "Deploying app...\n"
az webapp deployment source config --branch master --name $appName --repo-url $gitDirectory

printf "\n"
printf "Done. :-)\n"
