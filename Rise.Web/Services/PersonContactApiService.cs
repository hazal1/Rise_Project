using Rise.Core.DTOs;

namespace Rise.Web.Services
{
    public class PersonContactApiService
    {
        private readonly HttpClient _httpClient;

        public PersonContactApiService(HttpClient httpClient)
        {
           _httpClient = httpClient;
        }

      
        public async Task<PersonContactDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PersonContactDto>>($"personcontact/{id}");
            return response.Data;


        }

        public async Task<PersonContactDto> SaveAsync(PersonContactDto newPersonContact)
        {
            var response = await _httpClient.PostAsJsonAsync("personcontact", newPersonContact);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<PersonContactDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(PersonContactDto newPersonContact)
        {
            var response = await _httpClient.PutAsJsonAsync("personcontact", newPersonContact);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"personcontact/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<PersonWithContactDto>> GetSinglePersonByIdContact(int personId)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<PersonWithContactDto>>>($"person/GetPersonByIdWithContact/{personId}");
            return response.Data;

        }
    }
}
