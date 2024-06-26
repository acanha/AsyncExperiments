﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncWeb
{
    public class Result
    {
        public async Task<int> GetNumberAsync()
        {
            await Task.Delay(5);
            return 5;
        }

        public async Task<int> GetNumberWithConfigureAwaitAsync()
        {
            await Task.Delay(5).ConfigureAwait(false);
            return 5;
        }

        private HttpClient _client = new HttpClient();

        public async Task<List<string>> GetBothAsync(string firstUrl, string secondUrl)
        {
            var result = new List<string>();
            var task1 = GetOneAsync(result, firstUrl);
            var task2 = GetOneAsync(result, secondUrl);
            await Task.WhenAll(task1, task2);
            return result;
        }

        private async Task GetOneAsync(List<string> result, string url)
        {
            var data = await _client.GetStringAsync(url);
            var weatherForecast = JsonConvert.DeserializeObject<Post>(data);
            result.Add(weatherForecast.Title);
        }

        public string DownloadStringV5(string url)
        {
            return Task.Run(() => {
                var request = _client.GetAsync(url).Result;
                var download = request.Content.ReadAsStringAsync().Result;
                return download;
            }).Result;
        }
    }

    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
