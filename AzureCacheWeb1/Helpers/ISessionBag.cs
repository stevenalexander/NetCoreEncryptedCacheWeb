namespace AzureCacheWeb1.Helpers
{
    public interface ISessionBag
    {
        string GetData();
        void SetData(string data);
    }
}
