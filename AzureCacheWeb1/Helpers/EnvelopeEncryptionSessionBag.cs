using Microsoft.AspNetCore.Http;

namespace AzureCacheWeb1.Helpers
{
    public class EnvelopeEncryptionSessionBag : ISessionBag
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        const string KEY = "key";
        const string DATA = "data";

        public EnvelopeEncryptionSessionBag(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetData()
        {
            // Get wrapped key

            // Unwrap key

            // Get encrypted data

            // Decrypt data

            return _session.GetString(DATA);
        }

        public void SetData(string data)
        {
            // Generate new key

            // Encrypt data

            // Wrap key

            // Store data and key

            _session.SetString(DATA, data);
        }
    }
}
