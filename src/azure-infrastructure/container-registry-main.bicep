param location string = resourceGroup().location
param containerRegistryName string
param environmentType string = 'dev'

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2023-07-01' = {
  name: containerRegistryName
  tags:{
    'environment':environmentType
  }
  location: location
  sku: {
    name: 'Basic'
  }
  properties: {
    adminUserEnabled: true
    publicNetworkAccess: 'Enabled'
    networkRuleBypassOptions: 'AzureServices'
  }
}

output loginServer string = containerRegistry.properties.loginServer
