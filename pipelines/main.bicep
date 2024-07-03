param location string = resourceGroup().location
param prefix string = 'timelogger'

param serviceNames object = {
  namespaceName: '${prefix}sb'
  queueName: '${prefix}queue'
  topicName: '${prefix}topic'
  subscriptionName: '${prefix}sub'
  keyVaultName: '${prefix}shrdkv'
}

param serviceBusConnectionString string

resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2022-10-01-preview' = {
  name: serviceNames.namespaceName
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
  properties: {
    minimumTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

resource serviceBusQueue 'Microsoft.ServiceBus/namespaces/queues@2022-10-01-preview' = {
  parent: serviceBusNamespace
  name: serviceNames.queueName
  properties: {
    lockDuration: 'PT5M'
    maxSizeInMegabytes: 1024
    requiresDuplicateDetection: false
    requiresSession: false
    defaultMessageTimeToLive: 'P7D'
    deadLetteringOnMessageExpiration: true
    duplicateDetectionHistoryTimeWindow: 'PT10M'
    maxDeliveryCount: 10
    enableBatchedOperations: true
  }
}

resource serviceBusTopic 'Microsoft.ServiceBus/namespaces/topics@2022-10-01-preview' = {
  parent: serviceBusNamespace
  name: serviceNames.topicName
  properties: {
    defaultMessageTimeToLive: 'P7D'
    requiresDuplicateDetection: false
    duplicateDetectionHistoryTimeWindow: 'PT10M'
    enableBatchedOperations: true
  }
}

resource serviceBusSubscription 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2022-10-01-preview' = {
  parent: serviceBusTopic
  name: serviceNames.subscriptionName
  properties: {
    lockDuration: 'PT5M'
    requiresSession: false
    defaultMessageTimeToLive: 'P7D'
    deadLetteringOnMessageExpiration: true
    maxDeliveryCount: 10
  }
}

resource keyVault 'Microsoft.KeyVault/vaults@2023-07-01' = {
  name: serviceNames.keyVaultName
  location: location
  properties: {
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: subscription().tenantId
    accessPolicies: []
    softDeleteRetentionInDays: 90
    enablePurgeProtection: true
    enableRbacAuthorization: false
    publicNetworkAccess: 'Enabled'
  }
}

resource keyVaultSecret 'Microsoft.KeyVault/vaults/secrets@2023-07-01' = {
  parent: keyVault
  name: 'ServiceBusConnection'
  properties: {
    value: serviceBusConnectionString
  }
}
