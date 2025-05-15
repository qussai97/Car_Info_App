using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInfoApp.Application.Interfaces;
using CarInfoApp.Domain.Models;
using System.Net.Http.Json;
namespace CarInfoApp.Infrastructure.Services
{
    public class NhtsaService : INhtsaService
    {
        private readonly HttpClient _httpClient;

        public NhtsaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Make>> GetAllMakesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<Make>>("https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");
            return response?.Results ?? new List<Make>();
        }

        public async Task<List<VehicleType>> GetVehicleTypesForMakeIdAsync(int makeId)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<VehicleType>>($"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json");
            return response?.Results ?? new List<VehicleType>();
        }

        public async Task<List<Model>> GetModelsForMakeIdAndYearAsync(int makeId, int year)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<Model>>($"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json");
            return response?.Results ?? new List<Model>();
        }
    }
}
