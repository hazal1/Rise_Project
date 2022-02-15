using Rise.Core.DTOs;

namespace Rise.Web.Services
{
    public class PersonApiService
    {
        private readonly HttpClient _httpClient;

        public PersonApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PersonWithContactDto>> GetPersonWithContact()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<PersonWithContactDto>>>("person/GetPersonWithContact");

            return response.Data;
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PersonDto>>($"person/{id}");
            return response.Data;


        }

        public async Task<PersonDto> SaveAsync(PersonDto newPerson)
        {
            var response = await _httpClient.PostAsJsonAsync("person", newPerson);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<PersonDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(PersonDto newPerson)
        {
            var response = await _httpClient.PutAsJsonAsync("person", newPerson);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"person/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<PersonWithContactDto> GetSinglePersonByIdContact(int personId)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PersonWithContactDto>>($"person/GetSinglePersonByIdContact/{personId}");
            return response.Data;
        }
    }
}
