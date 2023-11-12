using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using P06Shop.Shared;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.Shop;

namespace P06Shop.Shared.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public OrderService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<ServiceResponse<Order>> CreateOrderAsync(Order Order)
        {
            var response = await _httpClient.PostAsJsonAsync(
                _appSettings.BaseOrderEndpoint.GetAllOrdersEndpoint,
                Order
            );
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>();
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteOrderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return result;
        }

        public async Task<ServiceResponse<List<Order>>> GetOrdersAsync()
        {
            var response = await _httpClient.GetAsync(
                _appSettings.BaseOrderEndpoint.GetAllOrdersEndpoint
            );
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse<List<Order>>
                {
                    Success = false,
                    Message = "HTTP request failed"
                };

            var json = await response.Content.ReadAsStringAsync();
            var result =
                JsonConvert.DeserializeObject<ServiceResponse<List<Order>>>(json)
                ?? new ServiceResponse<List<Order>>
                {
                    Success = false,
                    Message = "Deserialization failed"
                };

            result.Success = result.Success && result.Data != null;

            return result;
        }

        public async Task<ServiceResponse<Order>> GetOrderByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(id.ToString());
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse<Order>
                {
                    Success = false,
                    Message = "HTTP request failed"
                };

            var json = await response.Content.ReadAsStringAsync();
            var result =
                JsonConvert.DeserializeObject<ServiceResponse<Order>>(json)
                ?? new ServiceResponse<Order>
                {
                    Success = false,
                    Message = "Deserialization failed"
                };

            result.Success = result.Success && result.Data != null;

            return result;
        }

        public async Task<ServiceResponse<Order>> UpdateOrderAsync(Order Order)
        {
            var response = await _httpClient.PutAsJsonAsync(
                _appSettings.BaseOrderEndpoint.GetAllOrdersEndpoint,
                Order
            );
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>();
            return result;
        }
    }
}
