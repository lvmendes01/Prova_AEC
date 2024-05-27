using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.AEC.Comum
{
    public class HttpClientHelper
    {
        private readonly HttpClient _client;

        public HttpClientHelper()
        {
            _client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string requestUri, string accessToken = null)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            HttpResponseMessage response = await _client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest content, string accessToken = null)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            string json = JsonConvert.SerializeObject(content);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(requestUri, httpContent);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseData);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest content, string accessToken = null)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            string json = JsonConvert.SerializeObject(content);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync(requestUri, httpContent);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseData);
        }

        public async Task DeleteAsync(string requestUri, string accessToken = null)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            HttpResponseMessage response = await _client.DeleteAsync(requestUri);
            response.EnsureSuccessStatusCode();
        }
    }
}