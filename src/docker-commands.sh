resourceGroup="rg-docker-sample"
containerRegistry="acisampleregistry2022"

#Assign username and password into variable
# acr_username=$(az acr credential show -n $containerRegistry --query username)
# acr_password=$(az acr credential show -n $containerRegistry --query passwords[0].value)

acr_username=acisampleregistry2022
acr_password=[AzureContainerRegistryAdminPassword]

##Build and Push images
sudo docker context use default
echo "Build images specified on the compose file..."
sudo docker-compose -f aci.docker-compose.yml build
sudo az acr login --name $containerRegistry -u $acr_username -p $acr_password
echo "Push images specified on the compose file..."
sudo docker-compose -f aci.docker-compose.yml push

# Create context
#Set up an ACI context in one Docker command allowing you to switch from a local context to a cloud context and run applications quickly and easily
echo "Create docker `aci` context..."
sudo docker context create aci test --resource-group $resourceGroup
sudo docker context use test
echo "Run images in Azure Container Instances..."
sudo docker compose -f aci.docker-compose.yml -p aci-sample-proj up

# Remove the ACI runned
# sudo docker compose -f aci.docker-compose.yml -p aci-sample-proj down	