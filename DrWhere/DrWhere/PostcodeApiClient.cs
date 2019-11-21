using System;
using System.Net.Http;

namespace DrWhere {
    public class PostcodeApiClient {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient() {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://api.postcodes.io");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applications/json"));
        }
    }
}