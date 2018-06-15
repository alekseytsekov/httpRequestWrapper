namespace HttpRequestWrapper
{
    using System.Threading.Tasks;

    public interface IHttpRequestWrapper
    {
        string MergeUrl(string baseUrl, string endpoint);
        Task<(int,string)> GetAsync(string baseUrl);
        Task<(int,string)> PostAsync(string baseUrl, string data);
        Task<(int,string)> PutAsync(string baseUrl, string data);
        Task<(int,string)> DeleteAsync(string baseUrl);
    }
}
