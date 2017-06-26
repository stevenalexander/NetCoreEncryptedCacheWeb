using System.Threading.Tasks;

namespace AzureCacheWeb1.Session
{
    public interface ISessionBag
    {
        Task<string> GetData();
        Task SetData(string data);
    }
}
