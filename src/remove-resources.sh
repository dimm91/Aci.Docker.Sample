resourceGroup="rg-docker-sample"

# Remove resources
echo "Removing resources..."
az group delete --name $resourceGroup

sudo docker context use default
sudo docker context rm test