using Amazon.S3.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace S3NetCoreClient.Client
{
    internal class Program
    {
        private static HttpClient _client;

        public static HttpClient Client
        {
            get
            {
                _client = _client ?? new HttpClient();
                return _client;
            }
        }

        private static void Main(string[] args)
        {
            Client.BaseAddress = new Uri("http://localhost:22831/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<S3Bucket> buckets = GetBuckets().GetAwaiter().GetResult();
            foreach (S3Bucket bucket in buckets)
            {
                Console.WriteLine(bucket.BucketName);
            }
            Console.WriteLine("Hello World!");
        }

        private async static Task<List<S3Bucket>> GetBuckets()
        {
            List<S3Bucket> buckets = new List<S3Bucket>();
            HttpResponseMessage response = await Client.GetAsync("api/S3BucketController");
            if (response.IsSuccessStatusCode)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                buckets = JsonConvert.DeserializeObject<List<S3Bucket>>(jsonResult);
            }
            return buckets;
        }
    }
}