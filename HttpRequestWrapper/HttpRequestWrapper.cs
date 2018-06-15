namespace HttpRequestWrapper
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpRequestWrapper : IHttpRequestWrapper
    {
        public async Task<(int, string)> GetAsync(string baseUrl)
        {
            string data;
            int statusCode;

            //The 'using' will help to prevent memory leaks.
            //Create a new instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                //Setting up the response...  
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        data = await content.ReadAsStringAsync();
                        statusCode = (int)res.StatusCode;
                    }
                }
            }
            
            return (statusCode, data);
        }

        public async Task<(int, string)> PostAsync(string baseUrl, string data)
        {
            string result;
            int statusCode;

            //The 'using' will help to prevent memory leaks.
            //Create a new instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                //Setting up the response...  
                using (HttpResponseMessage res = await client.PostAsync(baseUrl, new StringContent(data, Encoding.UTF8, "application/json")))
                {
                    using (HttpContent content = res.Content)
                    {
                        result = await content.ReadAsStringAsync();
                        statusCode = (int)res.StatusCode;
                    }
                }
            }
            
            return (statusCode, result);
        }

        public async Task<(int, string)> PutAsync(string baseUrl, string data)
        {
            string result;
            int statusCode;

            //The 'using' will help to prevent memory leaks.
            //Create a new instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                //Setting up the response...  
                using (HttpResponseMessage res = await client.PutAsync(baseUrl, new StringContent(data, Encoding.UTF8, "application/json")))
                {
                    using (HttpContent content = res.Content)
                    {
                        result = await content.ReadAsStringAsync();
                        statusCode = (int)res.StatusCode;
                    }
                }
            }
            
            return (statusCode, result);
        }

        public async Task<(int, string)> DeleteAsync(string baseUrl)
        {
            string result;
            int statusCode;

            //The 'using' will help to prevent memory leaks.
            //Create a new instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                //Setting up the response...
                using (HttpResponseMessage res = await client.DeleteAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        result = await content.ReadAsStringAsync();
                        statusCode = (int)res.StatusCode;
                    }
                }
            }
            
            return (statusCode, result);
        }

        public string MergeUrl(string baseUrl, string endpoint)
        {
            string result = baseUrl.TrimEnd('/') + "/" + endpoint.Trim('/');

            return result;
        }
    }
}
