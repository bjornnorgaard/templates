# Scripts
This template ships with various script for task automation. These are descriped in futher detail below.

- [Scripts](#scripts)
  - [Rename-Project](#rename-project)
  - [New-AzureProject](#new-azureproject)
  - [Add-InstrumentationKey](#add-instrumentationkey)

## Rename-Project
Updates the common project prefix and all usage in the repository. Note that this is case-sensitive and will not usages which are not all uppercase. At this point these have to be updated manually.

## New-AzureProject
Configures the Azure environment for three apps (test, staging and production) and sets up CD from the created docker registry.

1. Resource Group
2. Service Plan
3. Container Registry
4. Key Vault
5. Webapp
   1. Creates deployment slots (test, staging, production)
   2. Setup container deployment
6. Webhooks for CD

Now the app will be updated whenever a new image is pushed.

## Add-InstrumentationKey
Adds an instrumentation key to the Key Vault created in the `New-AzureProject` script.
