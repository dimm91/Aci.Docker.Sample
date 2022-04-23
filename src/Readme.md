
# Docker ACI Sample

## Pre-requisite

- [Install Docker Compose CLI](https://docs.docker.com/cloud/aci-integration/#install-the-docker-compose-cli-on-linux)
- Have an azure account

## Resources 
- [Run Docker containers on ACI](https://docs.docker.com/cloud/aci-integration/#run-docker-containers-on-aci)
- [Microsoft sample](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-tutorial-prepare-app)

## Acure Container Instances

> Azure Container Instances (ACI) is a managed service that allows you to run containers directly on the public cloud. By design, it is not intended to be a full orchestration platform.

For this example there are 3 shell scripts:
* [azure-Commands.sh](azure-Commands.sh) 
* [docker-Commands.sh](docker-Commands.sh) 
* [remove-resources.sh](remove-resources.sh) 


## azure-Commands.sh

This script will create the required azure resources:
* Resource Group
* Azure Sql Server
* Azure Container Registry

## docker-Commands.sh

> FYI. The images need to be on an container registry.

This script will `build` and `push` the images specified on [aci.docker-compose.yml](aci.docker-compose.yml) into the Azure Container Registry created in the previous script.

This will also create a docker `context` linked to the resource group created in the previous script.

> Docker contexts are useful when you need to deploy containers in multiple independent environments. You can set up contexts for your local Docker socket, a shared team staging server, and your production Kubernetes server

Finally the [ACI](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-overview) will be created with the containers running internally.

 ## Remove everything

 You can reset everything by running the script [remove-resources.sh](remove-resources.sh)

