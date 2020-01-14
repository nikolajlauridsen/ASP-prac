using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gavebod2.Services
{
    public class APIService: IAPIService
    {
        private readonly IHttpClientFactory _clientFactory;

        public APIService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetObject<T>(string endPoint, int id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{endPoint}/{id}");
            HttpClient client = _clientFactory.CreateClient("api");
            HttpResponseMessage response = await client.SendAsync(request);

            T obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return obj;
        }

        public async Task<T> GetAll<T>(string endPoint)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, endPoint);
            HttpClient client = _clientFactory.CreateClient("api");
            HttpResponseMessage response = await client.SendAsync(request);

            T objects = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return objects;
        }

        public async void InsertObject<T>(string endPoint, T obj)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, endPoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            HttpClient client = _clientFactory.CreateClient("api");
            await client.SendAsync(request);
        }

        public async void UpdateObject<T>(string endPoint, T obj, int id)
        {
            throw new NotImplementedException();
        }

        public async void DeleteObject(string endPoint, int id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{endPoint}/{id}");
            HttpClient client = _clientFactory.CreateClient("api");
            await client.SendAsync(request);
        }
    }
}
