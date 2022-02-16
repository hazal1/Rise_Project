using Rise.Core.DTOs;

namespace Rise.Web.Services
{
    public class CityApiService
    {
        private readonly HttpClient _httpClient;

        public CityApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CityDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CityDto>>>("city");
            return response.Data;
        }

    }
}
