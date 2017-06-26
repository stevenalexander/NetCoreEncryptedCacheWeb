using AzureCacheWeb1.Helpers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AzureCacheWeb1.Session
{
    public class EnvelopeEncryptionSessionBag : ISessionBag
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private IVaultHelper _vaultHelper;

        const string KEY = "key";
        const string DATA = "data";

        public EnvelopeEncryptionSessionBag(IHttpContextAccessor httpContextAccessor, IVaultHelper vaultHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _vaultHelper = vaultHelper;
        }

        public async Task<string> GetData()
        {
            // Get wrapped key
            var wrappedKey = _session.Get(KEY);
            var encryptedData = _session.Get(DATA);

            if (wrappedKey != null && encryptedData != null)
            {
                // Unwrap key
                var unwrappedKey = await _vaultHelper.UnwrapKey(wrappedKey);
                
                // Decrypt data
                var decryptedData = EncryptionHelper.DecryptStringFromBytes_Aes(encryptedData, unwrappedKey);

                return decryptedData;
            }
            else
            {
                return null;
            }
        }

        public async Task SetData(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                // Generate new key
                var key = EncryptionHelper.GetKey();

                // Encrypt data
                var encryptedData = EncryptionHelper.EncryptStringToBytes_Aes(data, key);

                // Wrap key
                var wrappedKey = await _vaultHelper.WrapKey(key);

                // Store data and key
                _session.Set(KEY, wrappedKey);
                _session.Set(DATA, encryptedData);
            }
        }
    }
}
