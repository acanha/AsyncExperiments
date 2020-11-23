using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncStandardLibrary
{
    public class TaskElidingCompilerGeneratedCode
    {
        public Task<string> GetElidingKeywordsAsync()
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                var task = httpClient.GetStringAsync("https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1");
                return task;
            }
            finally
            {
                if (httpClient != null)
                {
                    ((IDisposable)httpClient).Dispose();
                }
            }
        }
    }
}
