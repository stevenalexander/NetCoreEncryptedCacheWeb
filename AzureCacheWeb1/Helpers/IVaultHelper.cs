using System.Threading.Tasks;

namespace AzureCacheWeb1.Helpers
{
    public interface IVaultHelper
    {
        Task<string> GetSecret(string secret);
        Task<byte[]> UnwrapKey(byte[] wrappedKey);
        Task<byte[]> WrapKey(byte[] unwrappedKey);
    }
}