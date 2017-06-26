using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;

namespace AzureCacheWeb1.Helpers
{
    public class VaultHelper : IVaultHelper
    {
        private string _vaultURL;
        private string _clientId;
        private string _clientSecret;

        private KeyVaultClient _keyVaultClient = null;

        private const string ALGORITHM = JsonWebKeyEncryptionAlgorithm.RSAOAEP; // Azure default

        public VaultHelper(string vaultURL, string clientId, string clientSecret)
        {
            _vaultURL = vaultURL;
            _clientId = clientId;
            _clientSecret = clientSecret;

            _keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetToken));
        }

        public async Task<string> GetSecret(string secret)
        {
            var result = await _keyVaultClient.GetSecretAsync(_vaultURL, secret);
            return result.Value;
        }

        private async Task<string> GetToken(string authority, string resource, string scope)
        {
            var clientCredentials = new ClientCredential(_clientId, _clientSecret);
            var authenticationContext = new AuthenticationContext(authority);
            var result = await authenticationContext.AcquireTokenAsync(resource, clientCredentials);
            return result.AccessToken;
        }

        public async Task<byte[]> WrapKey(byte[] unwrappedKey)
        {
            var wrappedKey = await _keyVaultClient.WrapKeyAsync(_vaultURL, ALGORITHM, unwrappedKey);
            return wrappedKey.Result;
        }


        public async Task<byte[]> UnwrapKey(byte[] wrappedKey)
        {
            var unwrappedKey = await _keyVaultClient.UnwrapKeyAsync(_vaultURL, ALGORITHM, wrappedKey);
            return unwrappedKey.Result;
        }
    }
}
