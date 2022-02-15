namespace Rise.Web.Services
{
    public class PersonContactApiService
    {
        private readonly HttpClient httpClient;

        public PersonContactApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
