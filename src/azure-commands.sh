resourceGroup="rg-docker-sample"
location="Germany West Central"
login="azureuser"
password="DockerAci2022"
server="azuresql-server-2022-aci-sample"
database="msdocsazuresqldb"
containerRegistry="acisampleregistry2022"
startIp=0.0.0.0
endIp=0.0.0.0

az login
echo "Creating the Azure resources..."

echo "Creating $resourceGroup in $location..."
az group create --name $resourceGroup --location "$location"

echo "Creating $server in $location..."
az sql server create --name $server --resource-group $resourceGroup --location "$location" --admin-user $login --admin-password $password

echo "Configuring firewall... (Allow Azure Services and resources to access this server)"
az sql server firewall-rule create --resource-group $resourceGroup --server $server -n AllowAzureServices --start-ip-address $startIp --end-ip-address $endIp

echo "Creating Azure Container Registry..."
az acr create --resource-group $resourceGroup --name $containerRegistry --sku Basic --admin-enabled
