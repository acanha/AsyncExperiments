using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWebFramework
{
    public static class Eliding
    {
        #region Using
        private const string URL = "https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1";

        public static async Task<string> GetWithKeywordsAsync()
        {
            using (var client = new HttpClient())
                return await client.GetStringAsync(URL);
        }

        public static Task<string> GetElidingKeywordsAsync()
        {
            using (var client = new HttpClient())
                return client.GetStringAsync(URL);
        }

        public static Task<string> GetElidingKeywordsWithTryAsync()
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
        #endregion

        #region Exceptions
        public static async Task<string> GetWithKeywordsExceptionAsync()
        {
            string parameter = GetParameter();
            return await DownloadStringAsync(parameter);
        }

        public static Task<string> GetElidingKeywordsExceptionAsync()
        {
            string parameter = GetParameter();
            return DownloadStringAsync(parameter);
        }

        private static string GetParameter()
        {
            throw new Exception("Some URL exception while.");
        }

        private static async Task<string> DownloadStringAsync(string url)
        {
            return await Task.FromResult("some string");
        }
        #endregion

        #region Stack Trace
        public static async Task Top(bool elide)
        {
            _ = elide ? await MiddleEliding() : await Middle();
        }

        public static async Task<int> Middle()
        {
            return await Bottom();
        }

        public static Task<int> MiddleEliding()
        {
            return Bottom();
        }

        public static async Task<int> Bottom()
        {
            await Task.Delay(10);
            throw new Exception("Bottom Exception");
        }
        #endregion

        #region AsyncLocal
        private static AsyncLocal<int> asyncLocalContext = new AsyncLocal<int>(Notify);

        static void Notify(AsyncLocalValueChangedArgs<int> args)
        {
            Debug.Assert(args.CurrentValue != args.PreviousValue);
        }
        public static async Task AsyncLocalWithoutEliding()
        {
            asyncLocalContext.Value = 1;
            Debug.Assert(asyncLocalContext.Value == 1);
            await Async();
            Debug.Assert(asyncLocalContext.Value == 1);
        }

        public static async Task AsyncLocalEliding()
        {
            asyncLocalContext.Value = 1;
            Debug.Assert(asyncLocalContext.Value == 1);
            await AsyncEliding();
            Debug.Assert(asyncLocalContext.Value == 1);
        }

        private static async Task Async()
        {
            Debug.Assert(asyncLocalContext.Value == 1);
            Sync();
            Debug.Assert(asyncLocalContext.Value == 2);
            await Task.Yield(); // force the method to be asynchronous
            Debug.Assert(asyncLocalContext.Value == 2);
        }

        private static Task AsyncEliding()
        {
            Debug.Assert(asyncLocalContext.Value == 1);
            asyncLocalContext.Value = 2;
            Debug.Assert(asyncLocalContext.Value == 2);
            return Task.CompletedTask;
        }

        private static void Sync()
        {
            Debug.Assert(asyncLocalContext.Value == 1);
            asyncLocalContext.Value = 2;
            Debug.Assert(asyncLocalContext.Value == 2);
        }
        #endregion
    }
}