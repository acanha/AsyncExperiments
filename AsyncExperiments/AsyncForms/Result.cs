namespace AsyncForms
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Result
    {
        private const string URL = "https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1";

        public static async Task<decimal> GetNumberAsync(decimal clicks)
        {
            await Task.Delay(5);
            return clicks + 1;
        }

        public static async Task<decimal> GetNumberWithConfigureAwaitAsync(decimal clicks)
        {
            await Task.Delay(5).ConfigureAwait(false);
            return clicks + 1;
        }

        public static async Task<string> GetWithKeywordsAsync()
        {
            using (var client = new HttpClient())
                return await client.GetStringAsync(URL);
        }

        public static Task<string> GetElidingKeywordsAsync()
        {
            try
            {
                using (var client = new HttpClient())
                    return client.GetStringAsync(URL);
            }
            catch (Exception e)
            {
                return Task.FromResult(e.Message);
            }
            
        }
    }
}
