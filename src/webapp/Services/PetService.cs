using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace webapp.Services
{
    public static class PetServiceExtensions
    {
        public static void AddPetService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<PetService>();
        }
    }

    public class PetService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;

        public PetService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseAddress = configuration["baseAddress"];
        }

        public async Task<IEnumerable<Pet>> GetAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAddress}/Pet");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                IEnumerable<Pet> pets = JsonConvert.DeserializeObject<IEnumerable<Pet>>(content);

                return pets;
            }

            throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
        }
    }
}