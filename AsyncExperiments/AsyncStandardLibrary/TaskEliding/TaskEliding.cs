using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncStandardLibrary
{
    public class TaskWithoutEliding
    {
        private const string URL = "https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1";

        public async Task<string> GetWithKeywordsAsync()
        {
            using (var client = new HttpClient())
                return await client.GetStringAsync(URL);
        }

        /*
            1. Creates the HttpClient object.
            2. Invoke GetStringAsync, which returns an incomplete task.
            3. Pauses the method until the task returned from GetStringAsync completes, returning an incomplete task.
            4. When the task returned from GetStringAsync completes, it resumes executing the method.
            5. Disposes the HttpClient object.
            6. Completes the task previously returned from GetElidingKeywordsAsync.
         */

        public Task<string> GetElidingKeywordsAsync()
        {
            using (var client = new HttpClient())
                return client.GetStringAsync(URL);
        }

        /*
            1. Create the HttpClient object.
            2. Invoke GetStringAsync, which returns an incomplete task.
            3. Disposes the HttpClient object.
            4. Returns the task that was returned from GetStringAsync.
         */
    }
}
