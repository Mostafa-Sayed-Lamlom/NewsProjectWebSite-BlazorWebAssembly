using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Services
{
    public class MainServices<T> : IMainServices<T> where T : class
    {
        public HttpClient _httpClient;
        public MainServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> AddNewRow(T entity, string ApiName)
        {
            var result = await _httpClient.PostAsJsonAsync<T>(ApiName, entity);
            if (!result.IsSuccessStatusCode)
            {
                var resultMsg = await result.Content.ReadAsStringAsync();
                throw new Exception(resultMsg);
            }
            return null;
        }

		public async Task<T> UpdateRow(T entity, string ApiName)
		{
			var result = await _httpClient.PutAsJsonAsync<T>(ApiName, entity);
			return await result.Content.ReadFromJsonAsync<T>();
		}

		public async Task<List<T>> GetAll(string ApiName)
        {
           return await _httpClient.GetFromJsonAsync<List<T>>(ApiName);
        }

        public async Task<T> GetRow(string ApiName)
        {
            return await _httpClient.GetFromJsonAsync<T>(ApiName);
        }

        public async Task DeleteRow(string ApiName)
        {
            await _httpClient.DeleteAsync(ApiName);
        }
    }
}
