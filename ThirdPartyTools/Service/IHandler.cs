namespace ThirdPartyTools.Service
{
    public interface IHandler
    {
        string GetResponse(string[] args);
        int GetSize(string path);
        string GetVersion(string path);
    }
}