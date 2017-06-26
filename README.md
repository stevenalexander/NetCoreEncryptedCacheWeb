# Azure cache using envelope encryption

Sample web app using Azure cache for session state with envelopment encryption.

This approach means data stored in session are encrypted at rest and transport.

## Requires

* Redis instance
* Azure Key Vault with key setup

NOTE: You must create an application registration with permission to the vault and to wrap/unwrap keys in Access Policies, this is NOT default in any of the role templates.

## Run

Set the config values in `appsettings.json` for the Redis connection string, vaultUrl (full Key Identifier URI), ClientId (also known as Application ID) and ClientSecret (key setup during Application Registration).

## Notes

* Key size used for AES (16) should be increased
* SessionBag should be extended to Get/Set using a generic serialisable object

## Links

* Envelopment approach description - https://docs.microsoft.com/en-us/azure/storage/storage-client-side-encryption
* AWS explanation of envelope encryption - http://docs.aws.amazon.com/kms/latest/developerguide/workflow.html
* Tutorial - https://docs.microsoft.com/en-us/azure/storage/storage-encrypt-decrypt-blobs-key-vault
* Creating identity for app - https://docs.microsoft.com/en-gb/azure/azure-resource-manager/resource-group-create-service-principal-portal
* Access a secret (more clear about where to ) - https://blogs.msdn.microsoft.com/kaevans/2016/10/31/using-azure-keyvault-to-store-secrets/
* Using Redis for session state - https://blogs.msdn.microsoft.com/luisdem/2016/09/06/azure-redis-cache-on-asp-net-core/